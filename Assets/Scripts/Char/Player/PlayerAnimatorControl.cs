using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour
{
    private static readonly string IS_ON_GROUND = "isOnGround";
    private static readonly string VELOCITY_X = "velocityX";
    private static readonly string VELOCITY_Y = "velocityY";

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputControl playerInputControl;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInputControl = GetComponent<PlayerInputControl>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimator();
    }

    private void SetAnimator()
    {
        animator.SetBool(IS_ON_GROUND, playerInputControl.isOnGround);
        animator.SetFloat(VELOCITY_X, Math.Abs(rb.velocity.x));
        animator.SetFloat(VELOCITY_Y, rb.velocity.y);
    }
}
