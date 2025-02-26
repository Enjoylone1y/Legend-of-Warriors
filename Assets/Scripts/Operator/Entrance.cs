using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IOperator;

public class Entrance : MonoBehaviour,IOperator
{
    public IOperator.OperatorType type { get => OperatorType.Entrance; set{ } }

    public void triggerOperate()
    {
        Debug.Log("triggerOperate");
    }
}
