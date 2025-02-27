using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class ScenesManager : MonoBehaviour
{
    /// <summary>
    /// 主场景
    /// </summary>
    public GameSceneSO mainScene;

    /// <summary>
    /// 场景加载事件请求
    /// </summary>
    public SceneLoadEventSO sceneRequest;
    /// <summary>
    /// 淡入淡出时间
    /// </summary>
    public int fadeInSec = 2;

    // 当前场景
    private GameSceneSO curScene;

    // 新场景数据
    private GameSceneSO newScene;
    private Vector3 pos2Go = Vector3.zero;
    private bool useFadeIn = false;

    // 加载操作
    private AsyncOperationHandle<SceneInstance> loadSceneOperator;

    private void Awake()
    {
        curScene = mainScene;
        curScene.sceneRefrence.LoadSceneAsync(LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        sceneRequest.LoadRequestEvent += OnRequestEnterScene;
    }

    private void OnDisable()
    {
        sceneRequest.LoadRequestEvent -= OnRequestEnterScene;
    }

    // 处理场景切换请求
    private void OnRequestEnterScene(GameSceneSO newScene, Vector3 pos, bool useFadeIn)
    {
        Debug.Log(string.Format("OnRequestEnterScene"));

        this.newScene = newScene;
        this.pos2Go.Set(pos.x, pos.y, pos.z);
        this.useFadeIn = useFadeIn;

        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        if(useFadeIn)
        {
            //TODO: 渐隐实现
        }
        yield return new WaitForSeconds(fadeInSec);

        // 卸载当前场景
        yield return curScene.sceneRefrence.UnLoadScene();

        // 加载当前场景
        loadSceneOperator = newScene.sceneRefrence.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadSceneOperator.Completed += OnSceneLoadCompite;
    }

    private void OnSceneLoadCompite(AsyncOperationHandle<SceneInstance> obj)
    {
        // 切换当前场景
        curScene = newScene;
        // 设置玩家位置
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = pos2Go;
    }

}
