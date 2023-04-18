using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn_Cover_StartPage : StartPageButtonBase
{
    public GameObject StartPage;
    public GameObject SettingPage;

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
        StartPage.SetActive(false);
        // ��ʾ���ý���
        SettingPage.SetActive(true);

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
