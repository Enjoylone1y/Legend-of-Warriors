using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightObj : Character
{
    [Header("属性")]
    public int maxHp = 100;
    public int curHp = 0;
    public int atkDamage = 1;
    public bool invincible = false;
    public int hurtInterval = 2;

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

    /* 攻击 */
    public virtual void Attack(FightObj target) { }

    /* 触碰伤害 */
    public virtual void CollisionAttack(FightObj target) { }

    /* 
     * 处理了受伤扣血和短暂无敌逻辑
     * 子类对象可以复写函数做受伤表现
     */
    public virtual void Hurt(int damage)
    {
        if(invincible) return;

        curHp = Math.Max(0, curHp -= damage);
        if (curHp <= 0 )
        {
            Die();
            return;
        }
        invincible = true;
        invincibleLeftTime = hurtInterval;
    }


    /* 角色死亡 */
    protected virtual void Die() { }

}
