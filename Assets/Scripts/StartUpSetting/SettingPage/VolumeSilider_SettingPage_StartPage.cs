using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.IO;
using System;

using Python.Runtime;



/// <summary>
/// 设置管理
/// </summary>
public class VolumeSilider_SettingPage_StartPage : PersistentSingleton<VolumeSilider_SettingPage_StartPage>
{
    [Header("音频混响器")]
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public SVGImage masterSVG;
    public SVGImage bgmSVG;
    public SVGImage sfxSVG;

     float masterVolume;
     float bgmVolume;
     float sfxVolume;

    static void InitializePython() {
        // 设置python文件夹路径
        PythonEngine.PythonHome = "C:\\Program Files\\Python310";

        // 初始化python引擎
        PythonEngine.Initialize();
    }

    // Start is called before the first frame update
    void Start() {
        // 设置SVG颜色
        // (彩蛋)
        // 调用pythonnet

        // 初始化python引擎
        PythonEngine.Initialize();
        using (Py.GIL()) {
            dynamic os = Py.Import("os");

            string current_path = Environment.CurrentDirectory;
            // string current_path = os.getcwd();
            // Debug.Log(current_path);

            // 转 "\" 为 "/"
            current_path = current_path.Replace("\\", "/");
            // 转 "//" 为 "/"
            current_path = current_path.Replace("//", "/");
            // Debug.Log(current_path);
            
            dynamic sys = Py.Import("sys");
            sys.path.append(current_path + "/Assets/Resources/StartPage_Related/Icons/");


            dynamic ColorSettingPyScript = Py.Import("set_svg_color");
            ColorSettingPyScript.main(current_path + "/Assets/Resources/StartPage_Related/Icons/");
        }

        // 获取音量滑动条的初始值，传递变量
        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("BGM", out bgmVolume);
        audioMixer.GetFloat("SFX", out bgmVolume);

        // 设置音量滑动条的初始值
        masterSlider.value = masterVolume;
        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // 动态设置音量图标
        masterSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(masterVolume));
        bgmSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(bgmVolume));
        sfxSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(sfxVolume));

        // 接下来绑定滑动条 和 滑动条改变函数
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    // 设置总音量
    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("Master", volume);
        // 动态设置音量图标
        masterSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }

    // 设置BGM音量
    public void SetBGMVolume(float volume) {
        audioMixer.SetFloat("BGM", volume);
        // 动态设置音量图标
        bgmSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }

    // 设置音效音量
    public void SetSFXVolume(float volume) {
        audioMixer.SetFloat("SFX", volume);
        // 动态设置音量图标
        sfxSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }


    // 根据声音音量判断声音图标
    public string GetVolumeIcon(float volume) {
        if (volume == -80) {
            return "volume-off";
        }
        else if (volume > -40) {
            return "volume-up";
        }
        else {
            return "volume-down";
        }
    }

}
