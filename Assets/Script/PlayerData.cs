using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType
{
    Knight = 0,
}

public class PlayerBase
{
    protected ClassType pb_ClassType;
    protected int pb_HealthPoints;
    protected int pb_Attack;
    protected int pb_Speed;
}

public class PlayerData : PlayerBase
{
    public PlayerData(ClassType type, int hp, int attack, int speed)
    {
        pb_ClassType = type;
        pb_HealthPoints = hp;
        pb_Attack = attack;
        pb_Speed = speed;
    }

    public ClassType GetClassType()
    {
        return pb_ClassType;
    }

    public int GetHP()
    {
        return pb_HealthPoints;
    }

    public int GetAttack()
    {
        return pb_Attack;
    }

    public int GetSpeed()
    {
        return pb_Speed;
    }
}
