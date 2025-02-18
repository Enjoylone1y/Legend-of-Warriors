using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour
{
    private static string IS_ON_GROUND = "isOnGround";
    private static string VELOCITY_X = "velocityX";
    private static string VELOCITY_Y = "velocityY";

    private Rigidbody2D rb;
    private Animator animator;
    private PhysicsCheck physicsCheck;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        physicsCheck = GetComponent<PhysicsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        setAnimator();
    }

    private void setAnimator()
    {
        animator.SetBool(IS_ON_GROUND, physicsCheck.isOnGround);
        animator.SetFloat(VELOCITY_X, Math.Abs(rb.velocity.x));
        animator.SetFloat(VELOCITY_Y, rb.velocity.y);
    }
}
