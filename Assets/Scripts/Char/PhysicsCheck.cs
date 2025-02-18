using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isOnGround = true;
    public float checkRadius = 0.05f;
    public Vector3 checkOffset = Vector3.zero;
    public LayerMask platformLayer;

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position + checkOffset, checkRadius, platformLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + checkOffset, checkRadius);
    }
}
