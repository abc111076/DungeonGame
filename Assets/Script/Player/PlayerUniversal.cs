using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected ClassType pb_ClassType;
    protected PlayerState pb_PlayerState;
    protected int pb_HealthPoints;
    protected int pb_Attack;
    protected int pb_Speed;
}

public class PlayerUniversal : PlayerBase
{
    protected ClassType roClassType { get { return pb_ClassType; } }
    protected PlayerState roPlayerState { get { return pb_PlayerState; } }
    protected int roHealthPoints { get { return pb_HealthPoints; } }
    protected int roAttack { get { return pb_Attack; } }
    protected int roSpeed { get { return pb_Speed; } }

    public void CreatePlayer(ClassType type, PlayerState state, int hp, int attack, int speed)
    {
        pb_ClassType = type;
        pb_PlayerState = state;
        pb_HealthPoints = hp;
        pb_Attack = attack;
        pb_Speed = speed;
    }

    public void ChangePlayerState(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.SlowRun:
                break;
            case PlayerState.Attack:
                break;
        }

        if (pb_PlayerState != state)
        {
            pb_PlayerState = state;
            PlayerManager.Instance.SetPlayerStateToManager(pb_PlayerState);
        }
    }
}
