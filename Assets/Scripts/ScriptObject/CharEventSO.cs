using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ʹ�� ScriptableObject ��ʵ�ֿ䳡�����¼�����
/// �� CharEventSO ������һ�� UnityAction ��һ���¼��������� RaiseEvent
/// ������ͨ�� ScriptableObject ʵ���� UnityAction ������¼�������
/// �¼��㲥��ͨ�� ScriptableObject ʵ�������¼��������� RaiseEvent ���㲥�¼�
/// </summary>
[CreateAssetMenu(menuName ="Event/CharEventSO")]
public class CharEventSO : ScriptableObject
{
    /// <summary>
    /// �¼�����
    /// </summary>
    public UnityAction<FightObj> OnEventRaised;

    /// <summary>
    /// �¼��������
    /// </summary>
    /// <param name="fightObj"> ս������ </param>
    public void RaiseEvent(FightObj fightObj)
    {
        OnEventRaised?.Invoke(fightObj);
    }
}
