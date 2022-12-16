using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    public enum AnimatorParamName { isMoving = 0, attack }

    public delegate void ChangePlayerStateDelegate(PlayerState state);
    public event ChangePlayerStateDelegate ChangePlayerStateHandler;

    public delegate void FinishAttackDelegate();
    public event FinishAttackDelegate FinishAttackHandler;

    public delegate void DoDamageDelegate();
    public event DoDamageDelegate DoDamageHandler;

    private const string TAG = "Knight";
    private const string ATTACK_TO_WALK_TRANSITION = "SwordSlash_Walk -> Walk";

    private Animator animator;
    private VariableJoystick variableJoystick;
    private PlayerUniversal playerU;
    private new Rigidbody rigidbody = null;
    private float verticleOffset = 1.0f;
    private float horizontalOffset = -1.0f;

    void Start()
    {
        variableJoystick = FindObjectOfType<VariableJoystick>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerU = GetComponent<PlayerUniversal>();
        variableJoystick.SetMode(JoystickType.Floating);
        AddAnimationEvent();
    }

    private void Update()
    {
        if (variableJoystick.Vertical != 0.0f && variableJoystick.Horizontal != 0.0f)
        {
            SetAnimatorBool(animator.GetParameter((int)AnimatorParamName.isMoving).name, true, PlayerState.Walk);
        }
        else if (variableJoystick.Vertical == 0.0f && variableJoystick.Horizontal == 0.0f)
        {
            SetAnimatorBool(animator.GetParameter((int)AnimatorParamName.isMoving).name, false, PlayerState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetAnimatorTrigger(animator.GetParameter((int)AnimatorParamName.attack).name, PlayerState.Attack);
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName(ATTACK_TO_WALK_TRANSITION))
        {
            ChangePlayerStateHandler(PlayerState.Walk);
        }
    }

    private void FixedUpdate()
    {
        if (variableJoystick.Vertical != 0.0f && variableJoystick.Horizontal != 0.0f)
        {
            Vector3 newVerticle = Vector3.forward + new Vector3(verticleOffset, 0.0f, 0.0f);
            Vector3 newHorizontal = Vector3.right + new Vector3(0.0f, 0.0f, horizontalOffset);
            Vector3 direction = newVerticle * variableJoystick.Vertical + newHorizontal * variableJoystick.Horizontal;

            if (IsSlope(rigidbody, out RaycastHit hit))
            {
                direction = Vector3.ProjectOnPlane(direction, hit.normal);
                transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            }
            else
            {
                if(direction != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(direction);
            }

            direction *= playerU.ROSpeed;
            rigidbody.velocity = direction;
        }
        else if (variableJoystick.Vertical == 0.0f && variableJoystick.Horizontal == 0.0f)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void SetAnimatorTrigger(string param, PlayerState state)
    {
        animator.SetTrigger(param);
        ChangePlayerStateHandler(state);
    }

    private void SetAnimatorBool(string param, bool value, PlayerState state)
    {
        if (animator.GetBool(param) != value)
        {
            animator.SetBool(param, value);
            ChangePlayerStateHandler(state);
        }
    }

    private void AddAnimationEvent()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < clips.Length; i++)
        {
            if (string.Equals(clips[i].name, "SwordSlash"))
            {
                AnimationEvent finishAttackEvent = new AnimationEvent();
                finishAttackEvent.functionName = "FinishAttack";
                finishAttackEvent.time = clips[i].length;
                clips[i].AddEvent(finishAttackEvent);
                AnimationEvent doDamageEvent = new AnimationEvent();
                doDamageEvent.functionName = "DoDamage";
                doDamageEvent.time = 0.83f;
                clips[i].AddEvent(doDamageEvent);
                break;
            }
        }

        animator.Rebind();
    }

    private void FinishAttack()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            ChangePlayerStateHandler(PlayerState.Idle);
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            ChangePlayerStateHandler(PlayerState.Walk);

        FinishAttackHandler();
    }

    private void DoDamage()
    {
        if(DoDamageHandler != null)
            DoDamageHandler();
    }

    private bool IsSlope(Rigidbody rb, out RaycastHit ohit)
    {
        ohit = default;
        float slopeHeightMaxDistance = 5f;
        float heightOffset = 2f;

        RaycastHit hit;
        if (Physics.Raycast(rb.position + Vector3.up * heightOffset, Vector3.down, out hit, slopeHeightMaxDistance, LayerMask.GetMask("Slope")))
        {
            ohit = hit;
            return hit.normal != Vector3.up;
        }

        return false;
    }
}
