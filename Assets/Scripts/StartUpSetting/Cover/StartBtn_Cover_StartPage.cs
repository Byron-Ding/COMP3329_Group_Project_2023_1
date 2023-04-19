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
     * ������
     */
    public override void MouseButtonLeftClick() {
        // �̳�
        base.MouseButtonLeftClick();


        // ��ʼ��Ϸ
        PlayGame();
    }

    public void PlayGame() {
        // ������һ������
        sceneLoader.LoadSceneWithFadeInOutEffect(sceneName: SceneData.SENCE_NAME_GAME_PLAY);


    }
}
