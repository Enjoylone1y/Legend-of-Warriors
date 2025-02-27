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
    /// ������
    /// </summary>
    public GameSceneSO mainScene;

    /// <summary>
    /// ���������¼�����
    /// </summary>
    public SceneLoadEventSO sceneRequest;
    /// <summary>
    /// ���뵭��ʱ��
    /// </summary>
    public int fadeInSec = 2;

    // ��ǰ����
    private GameSceneSO curScene;

    // �³�������
    private GameSceneSO newScene;
    private Vector3 pos2Go = Vector3.zero;
    private bool useFadeIn = false;

    // ���ز���
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

    // �������л�����
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
            //TODO: ����ʵ��
        }
        yield return new WaitForSeconds(fadeInSec);

        // ж�ص�ǰ����
        yield return curScene.sceneRefrence.UnLoadScene();

        // ���ص�ǰ����
        loadSceneOperator = newScene.sceneRefrence.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadSceneOperator.Completed += OnSceneLoadCompite;
    }

    private void OnSceneLoadCompite(AsyncOperationHandle<SceneInstance> obj)
    {
        // �л���ǰ����
        curScene = newScene;
        // �������λ��
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = pos2Go;
    }

}
