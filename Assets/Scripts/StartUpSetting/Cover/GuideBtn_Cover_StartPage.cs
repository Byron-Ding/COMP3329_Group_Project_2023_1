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

    // 按下鼠标中键
    public override void MouseButtonMiddleClick() {
        base.MouseButtonMiddleClick();

        // 彩蛋
        // 调用已经准备好的python脚本
        // 调用pythonnet

        // 初始化python引擎
        PythonEngine.Initialize();
        using (Py.GIL()) {
            string current_path = Environment.CurrentDirectory;
            Debug.Log(current_path);

            // 转 "\" 为 "/"
            current_path = current_path.Replace("\\", "/");
            // 转 "//" 为 "/"
            current_path = current_path.Replace("//", "/");

            dynamic sys = Py.Import("sys");
            sys.path.append(current_path);

            dynamic EasterEggPyScript = Py.Import("UserPyScripts.DefaultEasterEgg.easter_egg_guide_btn");

            EasterEggPyScript.open_url_hku_homepage();
        }
    }

    /*
     * 切换页面
     */
    private void SwitchPage() {
        // 隐藏原先界面
        sceneData.Cover_StartPage.SetActive(false);
        // 显示Guide界面
        sceneData.GuidePage_StartPage.SetActive(true);
    }

    /*
     * <summary>
     * 鼠标左键，隐藏当前页面
     * 显示Guide页面
     * </summary>
     */
    public override void MouseButtonLeftClick() {
        base.MouseButtonLeftClick();

        // 切换页面
        SwitchPage();
    }
}
