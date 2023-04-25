using System.Collections;
using System.Collections.Generic;
using TMPro;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
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
     * �����û��������������
     */
    public void SaveName() {

        GameObject root = GameObject.Find("Canvas_StartPage");
        GameObject Cover_StartPage = root.transform.Find("Cover_StartPage").gameObject;
        GameObject Name_Setting_Cover_StartPage = Cover_StartPage.transform.Find("Name_Setting_Cover_StartPage").gameObject;
        GameObject NameInputField_Cover_StartPage = Name_Setting_Cover_StartPage.transform.Find("NameInputField_Cover_StartPage").gameObject;
        // GameObject NameInputFieldText_Cover_StartPage = NameInputField_Cover_StartPage.transform.Find("Text Area/Text").gameObject;

        // Name_Setting_Cover_StartPage.SetActive(false);
        // NameInputField_Cover_StartPage.SetActive(false);

        TMP_InputField textNameInputFieldText_Cover_StartPage = NameInputField_Cover_StartPage.GetComponent<TMP_InputField>();

        // Debug.Log(textNameInputFieldText_Cover_StartPage);

        // ��ȡ���������
        string inputtedName = textNameInputFieldText_Cover_StartPage.text;

        // �ʵ���������� HKU Pressure��
        if (inputtedName == "HKU Pressure") {


            // ��Unity ǿ�Ʊ���
            UnityEngine.Diagnostics.Utils.ForceCrash(ForcedCrashCategory.AccessViolation);
        }

        // ������Ϣ�������
        data_StartPage.player_name = inputtedName;


        // Debug.Log(data_StartPage.player_name);
    }

    public override void MouseButtonLeftClick() {
        SaveName();
    }


}
