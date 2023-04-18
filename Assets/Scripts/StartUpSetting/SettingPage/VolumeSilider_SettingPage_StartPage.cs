using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;



/// <summary>
/// ���ù���
/// </summary>
public class VolumeSilider_SettingPage_StartPage : MonoBehaviour
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


    // Start is called before the first frame update
    void Start() {
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
