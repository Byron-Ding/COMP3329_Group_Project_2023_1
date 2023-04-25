using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_SettingPage : StartPageButtonBase {


    public SceneData sceneData;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    // ����������
    public void returnToStartPage () {
        sceneData.Cover_StartPage.SetActive(true);
        sceneData.SettingPage_StartPage.SetActive(false);
    }

    // ���������������������
    public override void MouseButtonLeftClick() {
        returnToStartPage();
    }


}
