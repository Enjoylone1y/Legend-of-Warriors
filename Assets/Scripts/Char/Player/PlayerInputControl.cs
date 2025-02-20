using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControl : MonoBehaviour
{
    [Header("控制参数")]
    public float moveSpeed = 200.0f;
    public float jumpFouce = 16.0f;

    [Header("物理检查")]
    public bool isOnGround = true;
    public float checkRadius = 0.05f;
    public Vector3 checkOffset = Vector3.zero;
    public LayerMask platformLayer;

    private Rigidbody2D rb;
    private PlayerInputSetting playerInput;

    private Vector2 velocity = Vector2.zero;
    private Vector2 scale = Vector2.one;
    private Vector2 force = Vector2.zero;

    [Header("受击")]
    public bool playHurtting = false;
    public int hurtFocus = 6;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInputSetting();
        playerInput.GamePlay.Jump.started += Jump;
    }

    private void OnEnable()
    {
        playerInput.GamePlay.Enable();
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position + checkOffset, checkRadius, platformLayer);
        if (!playHurtting) {
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
        if (isOnGround && !playHurtting)
        {
            force.Set(force.x, jumpFouce);
            rb.AddForce(force, ForceMode2D.Impulse);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + checkOffset, checkRadius);
    }
}
