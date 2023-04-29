using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 音频管理器
/// 存储所有音频
/// 可以播放，停止
/// </summary>

public class AudioManagerDZD : MonoBehaviour {

    /// <summary>
    /// 存储单个音频的信息
    /// </summary>
    [System.Serializable]
    public class Sound {

        [Header("音频名称")]
        public string name;

        [Header("音频文件")]
        public AudioClip clip;

        [Header("音频音量")]
        [Range(0f, 1f)]
        public float volume;

        [Header("音频是否开局播放")]
        public bool playOnAwake;

        [Header("音频是否循环")]
        public bool loop;

    }
    /// <summary>
    /// 存储所有的音频信息
    /// </summary>
    public List<Sound> sounds;
    /// <summary>
    /// 音频字典信息
    /// </summary>
    private Dictionary<string, AudioSource> audioSourcesDic;

    /// <summary>
    /// 单例
    /// </summary>
    private static AudioManagerDZD instance;


    /// <summary>
    /// 播放某个音频
    /// </summary>
    /// <param name="name">音频名字</param>
    /// <param name="isWait">是否等待音频播放完</param>
    public static void PlayAudio(string name, bool isWait = false) {

        if (!instance.audioSourcesDic.ContainsKey(name)) {
            Debug.LogError($"没有{name}这个音频");
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
    /// 停止某个音频
    /// </summary>
    /// <param name="name">音频名</param>
    public static void StopAudio(string name) {
        if (!instance.audioSourcesDic.ContainsKey(name)) {
            Debug.LogError($"没有{name}这个音频");
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
