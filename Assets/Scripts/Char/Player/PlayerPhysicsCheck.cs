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

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position + checkOffset, checkRadius, platformLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + checkOffset, checkRadius);
    }
}
