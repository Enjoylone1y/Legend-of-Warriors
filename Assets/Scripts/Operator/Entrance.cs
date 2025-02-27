using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IOperator;

public class Entrance : MonoBehaviour,IOperator
{
    public IOperator.OperatorType type { get => OperatorType.Entrance; set{ } }
    public SceneLoadEventSO sceneLoadEvent;
    public GameSceneSO sceneToGo;
    public Vector3 pos2Go;

    public void triggerOperate()
    {
        Debug.Log(string.Format("triggerOperate:{0}", type));
        // ��������³���
        sceneLoadEvent.LoadRequestEvent(sceneToGo, pos2Go, false);
    }
}
