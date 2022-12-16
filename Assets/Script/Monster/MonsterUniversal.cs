using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField]
    protected int mb_HealthPoints;
    [SerializeField]
    protected int mb_Attack;
    [SerializeField]
    protected int mb_Speed;
}

public abstract class MonsterUniversal : MonsterBase
{
    public void CreateMonster(int hp, int attack, int speed)
    {
        mb_HealthPoints = hp;
        mb_Attack = attack;
        mb_Speed = speed;
    }

    public void ChangeMonsterState(MonsterState state)
    {

    }

    public void OnHit(int index, int damage, MonsterManager.CheckMonsterIsDead callback)
    {
        mb_HealthPoints -= damage;

        if(mb_HealthPoints <= 0)
        {
            callback(index);
        }
    }
}
