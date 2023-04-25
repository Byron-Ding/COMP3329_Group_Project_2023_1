using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ��Ƶ������
/// �洢������Ƶ
/// ���Բ��ţ�ֹͣ
/// </summary>

public class AudioManagerDZD : MonoBehaviour {

    /// <summary>
    /// �洢������Ƶ����Ϣ
    /// </summary>
    [System.Serializable]
    public class Sound {

        [Header("��Ƶ����")]
        public string name;

        [Header("��Ƶ�ļ�")]
        public AudioClip clip;

        [Header("��Ƶ����")]
        [Range(0f, 1f)]
        public float volume;

        [Header("��Ƶ�Ƿ񿪾ֲ���")]
        public bool playOnAwake;

        [Header("��Ƶ�Ƿ�ѭ��")]
        public bool loop;

    }
    /// <summary>
    /// �洢���е���Ƶ��Ϣ
    /// </summary>
    public List<Sound> sounds;
    /// <summary>
    /// ��Ƶ�ֵ���Ϣ
    /// </summary>
    private Dictionary<string, AudioSource> audioSourcesDic;

    /// <summary>
    /// ����
    /// </summary>
    private static AudioManagerDZD instance;


    /// <summary>
    /// ����ĳ����Ƶ
    /// </summary>
    /// <param name="name">��Ƶ����</param>
    /// <param name="isWait">�Ƿ�ȴ���Ƶ������</param>
    public static void PlayAudio(string name, bool isWait = false) {

        if (!instance.audioSourcesDic.ContainsKey(name)) {
            Debug.LogError($"û��{name}�����Ƶ");
            return;
        }

        if (isWait) {
            if (!instance.audioSourcesDic[name].isPlaying) {
                instance.audioSourcesDic[name].Play();
            }
        } else {
            instance.audioSourcesDic[name].Play();
        }

    }

    /// <summary>
    /// ֹͣĳ����Ƶ
    /// </summary>
    /// <param name="name">��Ƶ��</param>
    public static void StopAudio(string name) {
        if (!instance.audioSourcesDic.ContainsKey(name)) {
            Debug.LogError($"û��{name}�����Ƶ");
            return;
        }
        instance.audioSourcesDic[name].Stop();
    }


    // Start is called before the first frame update
    void Start() {
        foreach (var sound in sounds) {
            GameObject obj = new GameObject(sound.clip.name);
            obj.transform.parent = transform;

            AudioSource source = obj.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.playOnAwake = sound.playOnAwake;
            source.loop = sound.loop;

            if (sound.playOnAwake) {
                source.Play();
            }

            audioSourcesDic.Add(sound.name, source);
        }
    }

    // Update is called once per frame
    void Update() {

    }
    private void Awake() {
        if (instance == null) {
            instance = this;
            audioSourcesDic = new Dictionary<string, AudioSource>();
        }
    }

}
