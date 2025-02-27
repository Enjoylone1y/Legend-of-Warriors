using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OperateHandler : MonoBehaviour
{

    public GameObject operateView;
    private bool isInOperateArea = false;
    private IOperator curOperator;
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
        if(isInOperateArea && curOperator != null)
        {
            // TODO：根据类型刷新显示
            switch (curOperator.type) 
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
            curOperator = collision.gameObject.GetComponent<IOperator>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInOperateArea = false;
        curOperator = null;
    }

    private void OnDisable()
    {
        InputSystem.onActionChange -= OnActionChange;
        playerInput.Disable();
    }

    private void OnActionChange(object obj, InputActionChange change)
    {
       // TODO 判断不同控制器类型

    }

    private void OnGameConfirm(InputAction.CallbackContext context)
    {
        if(isInOperateArea && curOperator != null && curOperator.type == IOperator.OperatorType.Entrance)
        {
            curOperator.triggerOperate();
        }
    }

}
