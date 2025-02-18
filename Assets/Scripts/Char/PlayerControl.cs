using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    
    public float moveSpeed = 200.0f;
    public float jumpFouce = 16.0f; 

    private Rigidbody2D rb;
    private PlayerInputControl playerInputControl;
    private PhysicsCheck physicsCheck;

    private Vector2 velocity = Vector2.zero;
    private Vector2 scale = Vector2.one;
    private Vector2 force = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputControl = new PlayerInputControl();
        physicsCheck = GetComponent<PhysicsCheck>();
        playerInputControl.GamePlay.Jump.started += Jump;
    }

 

    private void OnEnable()
    {
        playerInputControl.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 move = playerInputControl.GamePlay.Move.ReadValue<Vector2>();
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
        if (physicsCheck.isOnGround)
        {
            force.Set(force.x, jumpFouce);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    private void OnDisable()
    {
        playerInputControl.Disable();
    }
}
