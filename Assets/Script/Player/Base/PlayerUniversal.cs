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
    protected ClassType ROClassType { get { return pb_ClassType; } }
    protected WeaponType ROWeaponType { get { return pb_WeaponType; } }
    protected PlayerState ROPlayerState { get { return pb_PlayerState; } }
    protected int ROHealthPoints { get { return pb_HealthPoints; } }
    protected int ROAttack { get { return pb_Attack; } }
    protected int ROSpeed { get { return pb_Speed; } }

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
        }

        pb_PlayerState = state;
        PlayerManager.Instance.SetPlayerStateToManager(pb_PlayerState);
    }

    public abstract void DoDamage();

    public abstract void FinishAttack();
}
