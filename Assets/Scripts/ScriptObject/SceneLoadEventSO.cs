using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �������������м��
/// </summary>
[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    /// <summary>
    /// ���������¼�
    /// </summary>
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    /// <summary>
    /// �����л�����
    /// </summary>
    /// <param name="scence"> ������Դ</param>
    /// <param name="pos2Go"> ������³���λ��</param>
    /// <param name="useFadeIn">�Ƿ��뵭��</param>
    public void RaiseLoadSceneEvent(GameSceneSO scence, Vector3 pos2Go, bool useFadeIn)
    {
        LoadRequestEvent?.Invoke(scence, pos2Go, useFadeIn);
    }
}
