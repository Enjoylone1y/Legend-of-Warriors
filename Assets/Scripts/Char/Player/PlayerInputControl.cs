using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerInputControl : MonoBehaviour
{
    [Header("控制参数")]
    public float moveSpeed = 200.0f;
    public float jumpFouce = 16.0f;

    private Rigidbody2D rb;
    private PlayerInputSetting playerInput;
    private PlayerPhysicsCheck playerPhysicsCheck;

    private Vector2 velocity = Vector2.zero;
    private Vector2 scale = Vector2.one;
    private Vector2 force = Vector2.zero;

    [Header("受击")]
    public bool playHurtting = false;
    public int hurtFocus = 6;

    public bool isAttack = false;

    private UnityEvent attackHandler = new UnityEvent();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPhysicsCheck = GetComponent<PlayerPhysicsCheck>();
        playerInput = new PlayerInputSetting();
        playerInput.GamePlay.Jump.started += Jump;
        playerInput.GamePlay.Attack.started += PlayerAttack;
    }

    private void OnEnable()
    {
        playerInput.GamePlay.Enable();
    }

    private void FixedUpdate()
    {
        if (!playHurtting && !isAttack) {
            Move();
        }
    }

    private void Move()
    {
        Vector2 move = playerInput.GamePlay.Move.ReadValue<Vector2>();
        float velocityX = move.x * moveSpeed * Time.deltaTime;
        velocity.Set(velocityX, rb.velocity.y);
        rb.velocity = velocity;
        float scaleX;
        if (velocityX < 0)
        {
            scaleX = -1;
        }
        else if (velocityX > 0)
        {
            scaleX = 1;
        }
        else 
        {
            scaleX = transform.localScale.x;
        }
        scale.Set(scaleX, 1);
        transform.localScale = scale;
    }


    private void Jump(InputAction.CallbackContext context)
    {
        if (playerPhysicsCheck.isOnGround && !playHurtting)
        {
            force.Set(force.x, jumpFouce);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    public void setAttackEvent(UnityAction action)
    {
        attackHandler.AddListener(action);
    }


    private void PlayerAttack(InputAction.CallbackContext context)
    {
        if (!playHurtting)
        {
            isAttack = true;
            attackHandler?.Invoke();
        }
    }

    public void OnHurt(Transform from)
    {
        playHurtting = true;
        rb.velocity = Vector2.zero;
        Vector2 direction = new Vector2(transform.position.x - from.position.x, 0).normalized;
        rb.AddForce(direction * hurtFocus, ForceMode2D.Impulse);
    }

    public void OnDead()
    {
        playerInput.GamePlay.Disable();
    }

    private void OnDisable()
    {
        playerInput.GamePlay.Disable();
    }


}
