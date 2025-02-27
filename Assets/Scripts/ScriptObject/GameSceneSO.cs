using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// 使用Addressable加载场景
/// 通过创建不同的 ScriptableObject 绑定不同的场景的资源引用
/// </summary>
[CreateAssetMenu(menuName = "GameScene/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    /// <summary>
    /// 场景资源引用
    /// </summary>
    public AssetReference sceneRefrence;


}
