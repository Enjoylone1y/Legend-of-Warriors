using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 使用 ScriptableObject 来实现夸场景的事件传递
/// 在 CharEventSO 中声明一个 UnityAction 和一个事件触发函数 RaiseEvent
/// 订阅者通过 ScriptableObject 实例往 UnityAction 中添加事件处理函数
/// 事件广播者通过 ScriptableObject 实例调用事件触发函数 RaiseEvent 来广播事件
/// </summary>
[CreateAssetMenu(menuName ="Event/CharEventSO")]
public class CharEventSO : ScriptableObject
{
    /// <summary>
    /// 事件对象
    /// </summary>
    public UnityAction<FightObj> OnEventRaised;

    /// <summary>
    /// 事件触发入口
    /// </summary>
    /// <param name="fightObj"> 战斗对象 </param>
    public void RaiseEvent(FightObj fightObj)
    {
        OnEventRaised?.Invoke(fightObj);
    }
}
