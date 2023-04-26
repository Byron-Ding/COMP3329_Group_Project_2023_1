using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : PersistentSingleton<SceneLoader>
{

    [SerializeField] UnityEngine.UI.Image transitionImage;
    [SerializeField] float transitionTime = 1f;

    Color color;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    /*
     * 淡入效果
     * 用于加载场景
     */
    public IEnumerator LoadCoroutine(string sceneName, GameObject scene) {

        // 画面中间会卡一下，是因为 SceneManager.LoadScene(sceneName) 函数问题
        // 用这个函数加载场景，会在加载场景的同时，把当前场景的所有对象都销毁掉
        // 在这里，Unity推荐使用异步版本 SceneManager.LoadSceneAsync(sceneName) 函数
        // 在开始淡出的的时候其实就可以开始加载新场景了
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        // 或者 var loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        // 教程用的是 var

        // 等待场景加载完成
        // 但是记得取消激活场景
        // 这样就不会影响之前的场景
        loadingOperation.allowSceneActivation = false;

        // 启用专场过渡图片
        transitionImage.gameObject.SetActive(true);

        // 从零开始加
        while (color.a < 1f) {
            // 要使用 unscaledDeltaTime，否则会受到 Time.timeScale 影响
            color.a += Time.timeScale / transitionTime;

            // 限制alpha透明度的最小值
            color.a = Mathf.Clamp01(color.a);

            // 把图片颜色赋值回去
            transitionImage.color = color;

            // 挂起，等待一帧
            yield return null;
        }

        // 关闭上个场景
        // transform.root.gameObject.SetActive(false);
        if (scene != null) {
            scene.SetActive(false);
        }

        // 淡出完成之后，再显示所需要的场景(之前异步加载)
        loadingOperation.allowSceneActivation = true;

        // 从1开始减
        while (color.a > 0f) {
            // 要使用 unscaledDeltaTime，否则会受到 Time.timeScale 影响
            color.a -= Time.timeScale / transitionTime;

            // 限制alpha透明度的最大值
            color.a = Mathf.Clamp01(color.a);

            // 把图片颜色赋值回去
            transitionImage.color = color;

            // 挂起，等待一帧
            yield return null;
        }

        // 关闭专场过渡图片，防止占用资源
        transitionImage.gameObject.SetActive(false);

    }
    public void LoadSceneWithFadeInOutEffect(string sceneName, GameObject scene = null) {
        // 淡入效果
        StartCoroutine(LoadCoroutine(sceneName, scene));
    }
}
