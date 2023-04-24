using Python.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBtn_Cover_StartPage : StartPageButtonBase
{
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

    // ��������м�
    public override void MouseButtonMiddleClick() {
        base.MouseButtonMiddleClick();

        // �ʵ�
        // �����Ѿ�׼���õ�python�ű�
        // ����pythonnet

        // ��ʼ��python����
        PythonEngine.Initialize();
        using (Py.GIL()) {
            string current_path = Environment.CurrentDirectory;
            Debug.Log(current_path);

            // ת "\" Ϊ "/"
            current_path = current_path.Replace("\\", "/");
            // ת "//" Ϊ "/"
            current_path = current_path.Replace("//", "/");

            dynamic sys = Py.Import("sys");
            sys.path.append(current_path);

            dynamic EasterEggPyScript = Py.Import("UserPyScripts.DefaultEasterEgg.easter_egg_guide_btn");

            EasterEggPyScript.open_url_hku_homepage();
        }
    }

    /*
     * �л�ҳ��
     */
    private void SwitchPage() {
        // ����ԭ�Ƚ���
        sceneData.Cover_StartPage.SetActive(false);
        // ��ʾGuide����
        sceneData.GuidePage_StartPage.SetActive(true);
    }

    /*
     * <summary>
     * �����������ص�ǰҳ��
     * ��ʾGuideҳ��
     * </summary>
     */
    public override void MouseButtonLeftClick() {
        base.MouseButtonLeftClick();

        // �л�ҳ��
        SwitchPage();
    }
}
