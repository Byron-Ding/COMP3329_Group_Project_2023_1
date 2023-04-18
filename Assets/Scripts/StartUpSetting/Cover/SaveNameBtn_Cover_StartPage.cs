using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNameBtn_Cover_StartPage : StartPageButtonBase {

    // Start is called before the first frame update
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    public override void Update() {
        base.Update();
    }



    /*
     * 保存用户输入的人物名字
     */
    public void SaveName() {
        // 获取输入框内容
        string inputtedName = GameObject.Find("NameInputField_StartPage").GetComponent<UnityEngine.UI.InputField>().text;

        // 传入信息储存的类
        Data_StartPage.player_name = inputtedName;


        // Debug.Log(Data_StartPage.player_name);
    }

    public override void MouseButtonLeftClick() {
        SaveName();
    }


}
