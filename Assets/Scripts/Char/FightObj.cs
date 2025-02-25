using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightObj : Character
{
    [Header("属性")]
    public float maxHp = 100.0f;
    public float curHp = 0;
    public int atkDamage = 1;
    public bool invincible = false;
    public int hurtInterval = 2;
    public bool dead = false;

    [Header("事件")]
    public CharEventSO CharEvent;

    private float invincibleLeftTime = 0;

    void Start()
    {
        isFightObj = true;
        curHp = maxHp;
    }

    void Update()
    {
        if (invincible) {
            invincibleLeftTime -= Time.deltaTime;
            if (invincibleLeftTime <= 0)
            {
                invincible = false;
            }
        }
    }

    /* 
     * 处理了受伤扣血和短暂无敌逻辑
     * 子类对象可以复写函数做受伤表现
     */
    public virtual bool Hurt(FightObj from, int damage)
    {
        if(invincible) return false;

        curHp = Math.Max(0, curHp -= damage);
        CharEvent.RaiseEvent(this);
        if (curHp <= 0 )
        {
            Die();
            return false;
        }
        invincible = true;
        invincibleLeftTime = hurtInterval;
        return true;
    }


    /* 角色死亡 */
    public virtual void Die() 
    {
        dead = true;
    }

}
