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
        // ͬ��˼·��ʵ��
        /*
        // ������ڱ༭�������У���ֹͣ����
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        
        // ������˳���Ϸ
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
     * ����˳���Ϸ
     */
    public override void MouseButtonLeftClick() {
        QuitGame();
    
    }

}
