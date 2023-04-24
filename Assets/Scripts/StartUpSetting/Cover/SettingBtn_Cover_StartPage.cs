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
     * ����ԭ�Ƚ��棬
     * ��ʾ���ý���
     */
    public void ShowSettingPage() {
        // ����ԭ�Ƚ���
        sceneData.Cover_StartPage.SetActive(false);
        // ��ʾ���ý���
        sceneData.SettingPage_StartPage.SetActive(true);

    }

    /*
     * ������
     */
    public override void MouseButtonLeftClick() {
        // �̳�
        base.MouseButtonLeftClick();
        // ��ʾ���ý���
        ShowSettingPage();
    }

}
