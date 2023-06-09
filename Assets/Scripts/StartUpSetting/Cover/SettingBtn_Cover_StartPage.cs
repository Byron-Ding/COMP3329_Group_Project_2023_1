using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn_Cover_StartPage : StartPageButtonBase
{
    public SceneData sceneData;

    // Start is called before the first frame update
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    public override void Update() {
        base.Update();
    }

    /*
     * 隐藏原先界面，
     * 显示设置界面
     */
    public void ShowSettingPage() {
        // 隐藏原先界面
        sceneData.Cover_StartPage.SetActive(false);
        // 显示设置界面
        sceneData.SettingPage_StartPage.SetActive(true);

    }

    /*
     * 鼠标左键
     */
    public override void MouseButtonLeftClick() {
        // 继承
        base.MouseButtonLeftClick();
        // 显示设置界面
        ShowSettingPage();
    }

}
