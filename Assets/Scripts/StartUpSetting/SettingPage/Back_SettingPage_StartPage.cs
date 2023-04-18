using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_SettingPage : StartPageButtonBase {


    public GameObject StartPage;
    public GameObject SettingsPage;

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

    // 返回主界面
    public void returnToStartPage () {
        StartPage.SetActive(true);
        SettingsPage.SetActive(false);
    }

    // 鼠标左键点击，返回主界面
    public override void MouseButtonLeftClick() {
        returnToStartPage();
    }


}
