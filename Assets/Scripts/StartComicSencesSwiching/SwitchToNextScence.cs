using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SwitchToNextScence : StartPageButtonBase
{

    // ͨ����ǩ��SceneLoader
    public SceneLoader sceneLoader;

    // ���¿ո���л����¸�����
    public override void Start() {
        base.Start();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
}


// �����������л��¸�����
public override void MouseButtonLeftClick() {
        // �л����¸�����
        // 1.��ȡ�¸�����������
        // ��ȡ��ǰ����������// ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ��ȡ��һ��������·��
        string nextScenePath = SceneUtility.GetScenePathByBuildIndex(currentSceneIndex + 1);
        // ��·������ȡ������������
        string nextSceneName = Path.GetFileNameWithoutExtension(nextScenePath);

        // 2. �л����¸�����
        sceneLoader.LoadSceneWithFadeInOutEffect(nextSceneName);
    }
}
