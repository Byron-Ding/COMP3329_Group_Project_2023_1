using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn_Cover_StartPage : StartPageButtonBase {

    // Start is called before the first frame update
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    public override void Update() {
        base.Update();
    }

    public void QuitGame() {
        // 同样思路的实现
        /*
        // 如果是在编辑器中运行，就停止播放
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        
        // 否则就退出游戏
        } else {
            Application.Quit();
        }
        */


        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif


    }

    /*
     * 左键退出游戏
     */
    public override void MouseButtonLeftClick() {
        QuitGame();
    
    }

}
