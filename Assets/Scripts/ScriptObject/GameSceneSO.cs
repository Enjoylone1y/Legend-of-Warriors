using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// ʹ��Addressable���س���
/// ͨ��������ͬ�� ScriptableObject �󶨲�ͬ�ĳ�������Դ����
/// </summary>
[CreateAssetMenu(menuName = "GameScene/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    /// <summary>
    /// ������Դ����
    /// </summary>
    public AssetReference sceneRefrence;


}
