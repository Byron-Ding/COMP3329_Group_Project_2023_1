using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn_StartPage : StartUpButtonBase
{
    public void QuitGame() {
        // ������ڱ༭�������У���ֹͣ����
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        
        // ������˳���Ϸ
        } else {
            Application.Quit();
        }


        // ͬ��˼·��ʵ��
        /*
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();

        #endif
        */


    }

    /*
     * ����˳���Ϸ
     */
    public override void MouseButtonLeftClick() {
        QuitGame();
    
    }

}
