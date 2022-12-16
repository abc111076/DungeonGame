using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected ClassType pb_ClassType;
    protected WeaponType pb_WeaponType;
    protected PlayerState pb_PlayerState;
    protected int pb_HealthPoints;
    protected int pb_Attack;
    protected int pb_Speed;
}

public abstract class PlayerUniversal : PlayerBase
{
    public ClassType ROClassType { get { return pb_ClassType; } }
    public WeaponType ROWeaponType { get { return pb_WeaponType; } }
    public PlayerState ROPlayerState { get { return pb_PlayerState; } }
    public int ROHealthPoints { get { return pb_HealthPoints; } }
    public int ROAttack { get { return pb_Attack; } }
    public int ROSpeed { get { return pb_Speed; } }

    private const string TAG = "PlayerUniversal";

    protected void CreatePlayer(ClassType ctype, WeaponType wtype, PlayerState state, int hp, int attack, int speed)
    {
        pb_ClassType = ctype;
        pb_WeaponType = wtype;
        pb_PlayerState = state;
        pb_HealthPoints = hp;
        pb_Attack = attack;
        pb_Speed = speed;
    }

    public void ChangePlayerState(PlayerState state)
    {
        if (pb_PlayerState == state) return;

        switch(state)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walk:
                break;
            case PlayerState.Attack:
                break;
            default:
                DebugUtility.DebugLogWithTag(TAG, "Something wrong in ChangePlayerState");
                break;
        }

        pb_PlayerState = state;
        PlayerManager.Instance.SetPlayerStateToManager(pb_PlayerState);
    }

    public abstract void DoDamage();

    public abstract void FinishAttack();
}
