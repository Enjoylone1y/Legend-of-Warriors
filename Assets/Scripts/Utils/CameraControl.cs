using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    private CinemachineConfiner2D confiner;
   

    private void Awake()
    {
        confiner = GetComponent<CinemachineConfiner2D>();
        
    }

    private void Start()
    {
        UpdateCameraNewBounds();
    }

    private void UpdateCameraNewBounds()
    {
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (obj == null) return;
        confiner.m_BoundingShape2D = obj.GetComponent<Collider2D>();
        // 清理上一个bounds的边界缓存
        confiner.InvalidateCache();
    }

    public void shakeCamera()
    {
        impulseSource.GenerateImpulse();
    }
}
