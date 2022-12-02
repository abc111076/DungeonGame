using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum AnimatorParamName { isMoving = 0, holdingSword, attack }

    public delegate void ChangePlayerStateDelegate(PlayerState state);
    public event ChangePlayerStateDelegate ChangePlayerStateHandler;

    public float speed;
    public bool isHoldingSword;
    private Animator animator;
    private float verticleOffset = 1.0f;
    private float horizontalOffset = -1.0f;
    private VariableJoystick variableJoystick;

    void Start()
    {
        variableJoystick = FindObjectOfType<VariableJoystick>();
        animator = GetComponent<Animator>();
        variableJoystick.SetMode(JoystickType.Floating);
        animator.SetBool("holdingSword", isHoldingSword);
    }

    public void Update()
    {
        if (variableJoystick.Vertical != 0.0f && variableJoystick.Horizontal != 0.0f)
        {
            SetAnimatorBool(animator.GetParameter((int)AnimatorParamName.isMoving).name, true, PlayerState.SlowRun);
            Vector3 newVerticle = Vector3.forward + new Vector3(verticleOffset, 0.0f, 0.0f);
            Vector3 newHorizontal = Vector3.right + new Vector3(0.0f, 0.0f, horizontalOffset);
            Vector3 direction = newVerticle * variableJoystick.Vertical + newHorizontal * variableJoystick.Horizontal;
            transform.rotation = Quaternion.LookRotation(transform.forward + direction);
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
        else if(variableJoystick.Vertical == 0.0f && variableJoystick.Horizontal == 0.0f)
        {
            SetAnimatorBool(animator.GetParameter((int)AnimatorParamName.isMoving).name, false, PlayerState.Idle);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetAnimatorTrigger(animator.GetParameter((int)AnimatorParamName.attack).name, PlayerState.Attack);
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
}
