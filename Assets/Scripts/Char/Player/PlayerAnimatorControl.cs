using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorControl : MonoBehaviour
{
    private static readonly string IS_ON_GROUND = "isOnGround";
    private static readonly string VELOCITY_X = "velocityX";
    private static readonly string VELOCITY_Y = "velocityY";
    private static readonly string TRIGGER_HURT = "hurt";
    private static readonly string DEAD = "dead";
    private static readonly string TRIGGER_ATTACK = "attack";
    private static readonly string IS_ATTACK = "isAttack";

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerPhysicsCheck playerPhysicsCheck;
    private PlayerInputControl playerInputControl;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerPhysicsCheck = GetComponent<PlayerPhysicsCheck>();
        playerInputControl = GetComponent<PlayerInputControl>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimator();
    }

    private void SetAnimator()
    {
        animator.SetBool(IS_ON_GROUND, playerPhysicsCheck.isOnGround);
        animator.SetFloat(VELOCITY_X, Math.Abs(rb.velocity.x));
        animator.SetFloat(VELOCITY_Y, rb.velocity.y);
        animator.SetBool(IS_ATTACK, playerInputControl.isAttack);
    }

    public void OnHurt()
    {
        animator.SetTrigger(TRIGGER_HURT);
    }

    public void playAttack()
    {
        animator.SetTrigger(TRIGGER_ATTACK);
    }

    public void OnDead()
    {
        animator.SetBool(DEAD, true);
    }
}
