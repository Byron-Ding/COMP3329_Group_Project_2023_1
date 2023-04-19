using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SaveNameBtn_Cover_StartPage : StartPageButtonBase {


    public Data_StartPage data_StartPage;
    // public TMP_InputField textNameInputField_StartPage;

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

        GameObject root = GameObject.Find("Canvas");
        GameObject Cover_StartPage = root.transform.Find("Cover_StartPage").gameObject;
        GameObject Name_Setting_Cover_StartPage = Cover_StartPage.transform.Find("Name_Setting_Cover_StartPage").gameObject;
        GameObject NameInputField_Cover_StartPage = Name_Setting_Cover_StartPage.transform.Find("NameInputField_Cover_StartPage").gameObject;
        // GameObject NameInputFieldText_Cover_StartPage = NameInputField_Cover_StartPage.transform.Find("Text Area/Text").gameObject;

        // Name_Setting_Cover_StartPage.SetActive(false);
        // NameInputField_Cover_StartPage.SetActive(false);

        TMP_InputField textNameInputFieldText_Cover_StartPage = NameInputField_Cover_StartPage.GetComponent<TMP_InputField>();

        // Debug.Log(textNameInputFieldText_Cover_StartPage);

        // 获取输入框内容
        string inputtedName = textNameInputFieldText_Cover_StartPage.text;

        // 传入信息储存的类
        data_StartPage.player_name = inputtedName;


        // Debug.Log(data_StartPage.player_name);
    }

    public override void MouseButtonLeftClick() {
        SaveName();
    }


}
