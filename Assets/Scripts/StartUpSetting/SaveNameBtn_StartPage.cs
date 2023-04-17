using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNameBtn_StartPage : StartPageButtonBase {

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
        // ��ȡ���������
        string inputtedName = GameObject.Find("NameInputField_StartPage").GetComponent<UnityEngine.UI.InputField>().text;

        // ������Ϣ�������
        Data_StartPage.player_name = inputtedName;


        // Debug.Log(Data_StartPage.player_name);
    }

    public override void MouseButtonLeftClick() {
        SaveName();
    }


}
