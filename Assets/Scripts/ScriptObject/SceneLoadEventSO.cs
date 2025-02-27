using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 场景加载请求中间件
/// </summary>
[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    /// <summary>
    /// 场景加载事件
    /// </summary>
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    /// <summary>
    /// 申请切换场景
    /// </summary>
    /// <param name="scence"> 场景资源</param>
    /// <param name="pos2Go"> 玩家在新场景位置</param>
    /// <param name="useFadeIn">是否淡入淡出</param>
    public void RaiseLoadSceneEvent(GameSceneSO scence, Vector3 pos2Go, bool useFadeIn)
    {
        LoadRequestEvent?.Invoke(scence, pos2Go, useFadeIn);
    }
}
