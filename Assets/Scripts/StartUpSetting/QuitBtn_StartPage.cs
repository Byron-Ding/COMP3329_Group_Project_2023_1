using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn_StartPage : StartUpButtonBase
{
    public void QuitGame() {
        // 如果是在编辑器中运行，就停止播放
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        
        // 否则就退出游戏
        } else {
            Application.Quit();
        }


        // 同样思路的实现
        /*
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();

        #endif
        */


    }

    /*
     * 左键退出游戏
     */
    public override void MouseButtonLeftClick() {
        QuitGame();
    
    }

}
