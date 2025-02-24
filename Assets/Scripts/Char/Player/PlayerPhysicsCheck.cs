using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsCheck : MonoBehaviour
{
    [Header("ŒÔ¿ÌºÏ≤È")]
    public bool isOnGround = true;
    public float checkRadius = 0.05f;
    public Vector3 checkOffset = Vector3.zero;
    public LayerMask platformLayer;

    private CapsuleCollider2D collider2D;

    private void Awake()
    {
        collider2D = gameObject.GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position + checkOffset, checkRadius, platformLayer);
        collider2D.sharedMaterial.friction = isOnGround ? 0.6f : 0f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + checkOffset, checkRadius);
    }
}
