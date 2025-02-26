using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OperateHandler : MonoBehaviour
{

    public GameObject operateView;
    private bool isInOperateArea = false;
    private IOperator.OperatorType? type = null;
    private PlayerInputSetting playerInput;


    private void Awake()
    {
        playerInput = new PlayerInputSetting();
    }

    private void OnEnable()
    {
        InputSystem.onActionChange += OnActionChange;
        playerInput.Enable();
        playerInput.GamePlay.Confirm.started += OnGameConfirm;
    }


    private void Update()
    {
        operateView.SetActive(isInOperateArea);
        if(isInOperateArea)
        {
            // TODO：根据类型刷新显示
            switch (type) 
            {
                default:
                    break;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Operatable"))
        {
            isInOperateArea = true;
            type = collision.gameObject.GetComponent<IOperator>()?.type;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInOperateArea = false;
        type = null;
    }

    private void OnDisable()
    {
        InputSystem.onActionChange -= OnActionChange;
        playerInput.Disable();
    }

    private void OnActionChange(object obj, InputActionChange change)
    {
       // TODO 判断不同控制类型

    }

    private void OnGameConfirm(InputAction.CallbackContext context)
    {
        if(isInOperateArea && type == IOperator.OperatorType.Entrance)
        {
            Debug.Log("进入场景");
        }
    }

}
