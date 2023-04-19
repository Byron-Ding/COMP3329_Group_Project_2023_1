using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn_Cover_StartPage : StartPageButtonBase {

    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    public override void Update() {
        base.Update();
    }

    /*
     * 鼠标左键
     */
    public override void MouseButtonLeftClick() {
        // 继承
        base.MouseButtonLeftClick();


        // 开始游戏
        PlayGame();
    }

    public void PlayGame() {
        // 加载下一个场景
        sceneLoader.LoadSceneWithFadeInOutEffect(sceneName: SceneData.SENCE_NAME_GAME_PLAY);


    }
}
