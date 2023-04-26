using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SwitchToNextScence : StartPageButtonBase
{

    // 通过标签找SceneLoader
    public SceneLoader sceneLoader;

    // 按下空格就切换到下个场景
    public override void Start() {
        base.Start();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
}


// 按下鼠标左键切换下个场景
public override void MouseButtonLeftClick() {
        // 切换到下个场景
        // 1.获取下个场景的名称
        // 获取当前场景的索引// 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // 获取下一个场景的路径
        string nextScenePath = SceneUtility.GetScenePathByBuildIndex(currentSceneIndex + 1);
        // 从路径中提取出场景的名称
        string nextSceneName = Path.GetFileNameWithoutExtension(nextScenePath);

        // 2. 切换到下个场景
        sceneLoader.LoadSceneWithFadeInOutEffect(nextSceneName);
    }
}
