using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FightObj
{
    private PlayerInputControl inputControl;
    private PlayerAnimatorControl animatorControl;

    private void Awake()
    {
        inputControl = GetComponent<PlayerInputControl>();
        animatorControl = GetComponent<PlayerAnimatorControl>();
    }

    public override void Attack(FightObj target)
    {
        
    }

    public override bool Hurt(FightObj from, int damage)
    {
        if (base.Hurt(from, damage))
        {
            inputControl.OnHurt(from.transform);
            animatorControl.OnHurt();
        }
        return true;
    }

    public override void Die()
    {
        inputControl.OnDead();
        animatorControl.OnDead();
    }
}
