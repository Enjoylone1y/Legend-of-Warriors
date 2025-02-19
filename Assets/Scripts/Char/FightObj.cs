using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightObj : Character
{
    [Header("����")]
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

    /* ���� */
    public virtual void Attack(FightObj target) { }

    /* �����˺� */
    public virtual void CollisionAttack(FightObj target) { }

    /* 
     * ���������˿�Ѫ�Ͷ����޵��߼�
     * ���������Ը�д���������˱���
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


    /* ��ɫ���� */
    protected virtual void Die() { }

}
