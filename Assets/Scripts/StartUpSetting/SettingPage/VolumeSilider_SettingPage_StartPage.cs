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
/// ���ù���
/// </summary>
public class VolumeSilider_SettingPage_StartPage : PersistentSingleton<VolumeSilider_SettingPage_StartPage>
{
    [Header("��Ƶ������")]
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
        // ����python�ļ���·��
        PythonEngine.PythonHome = "C:\\Program Files\\Python310";

        // ��ʼ��python����
        PythonEngine.Initialize();
    }

    // Start is called before the first frame update
    void Start() {
        // ����SVG��ɫ
        // (�ʵ�)
        // ����pythonnet

        // ��ʼ��python����
        PythonEngine.Initialize();
        using (Py.GIL()) {
            dynamic os = Py.Import("os");

            string current_path = Environment.CurrentDirectory;
            // string current_path = os.getcwd();
            Debug.Log(current_path);

            // ת "\" Ϊ "/"
            current_path = current_path.Replace("\\", "/");
            // ת "//" Ϊ "/"
            current_path = current_path.Replace("//", "/");
            Debug.Log(current_path);
            
            dynamic sys = Py.Import("sys");
            sys.path.append(current_path + "/Assets/Resources/StartPage_Related/Icons/");


            dynamic ColorSettingPyScript = Py.Import("set_svg_color");
            ColorSettingPyScript.main(current_path + "/Assets/Resources/StartPage_Related/Icons/");
        }

        // ��ȡ�����������ĳ�ʼֵ�����ݱ���
        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("BGM", out bgmVolume);
        audioMixer.GetFloat("SFX", out bgmVolume);

        // ���������������ĳ�ʼֵ
        masterSlider.value = masterVolume;
        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // ��̬��������ͼ��
        masterSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(masterVolume));
        bgmSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(bgmVolume));
        sfxSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(sfxVolume));

        // �������󶨻����� �� �������ı亯��
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    // ����������
    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("Master", volume);
        // ��̬��������ͼ��
        masterSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }

    // ����BGM����
    public void SetBGMVolume(float volume) {
        audioMixer.SetFloat("BGM", volume);
        // ��̬��������ͼ��
        bgmSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }

    // ������Ч����
    public void SetSFXVolume(float volume) {
        audioMixer.SetFloat("SFX", volume);
        // ��̬��������ͼ��
        sfxSVG.sprite = Resources.Load<Sprite>("StartPage_Related/Icons/" + GetVolumeIcon(volume));
    }


    // �������������ж�����ͼ��
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
