using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : PersistentSingleton<SceneLoader>
{

    [SerializeField] UnityEngine.UI.Image transitionImage;
    [SerializeField] float transitionTime = 3.5f;

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
     * ����Ч��
     * ���ڼ��س���
     */
    public IEnumerator LoadCoroutine(string sceneName) {

        // �����м�Ῠһ�£�����Ϊ SceneManager.LoadScene(sceneName) ��������
        // ������������س��������ڼ��س�����ͬʱ���ѵ�ǰ���������ж������ٵ�
        // �����Unity�Ƽ�ʹ���첽�汾 SceneManager.LoadSceneAsync(sceneName) ����
        // �ڿ�ʼ�����ĵ�ʱ����ʵ�Ϳ��Կ�ʼ�����³�����
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        // ���� var loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        // �̳��õ��� var

        // �ȴ������������
        // ���Ǽǵ�ȡ�������
        // �����Ͳ���Ӱ��֮ǰ�ĳ���
        loadingOperation.allowSceneActivation = false;

        // ����ר������ͼƬ
        transitionImage.gameObject.SetActive(true);

        // ���㿪ʼ��
        while (color.a < 1f) {
            // Ҫʹ�� unscaledDeltaTime��������ܵ� Time.timeScale Ӱ��
            color.a += Time.unscaledDeltaTime / transitionTime;

            // ����alpha͸���ȵ���Сֵ
            color.a = Mathf.Clamp01(color.a);

            // ��ͼƬ��ɫ��ֵ��ȥ
            transitionImage.color = color;

            // ���𣬵ȴ�һ֡
            yield return null;
        }
        // �ر��ϸ�����
        transform.root.gameObject.SetActive(false);

        // �������֮������ʾ����Ҫ�ĳ���(֮ǰ�첽����)
        loadingOperation.allowSceneActivation = true;

        // ��1��ʼ��
        while (color.a > 0f) {
            // Ҫʹ�� unscaledDeltaTime��������ܵ� Time.timeScale Ӱ��
            color.a -= Time.unscaledDeltaTime / transitionTime;

            // ����alpha͸���ȵ����ֵ
            color.a = Mathf.Clamp01(color.a);

            // ��ͼƬ��ɫ��ֵ��ȥ
            transitionImage.color = color;

            // ���𣬵ȴ�һ֡
            yield return null;
        }

        // �ر�ר������ͼƬ����ֹռ����Դ
        transitionImage.gameObject.SetActive(false);

    }
    public void LoadSceneWithFadeInOutEffect(string sceneName) {
        // ����Ч��
        StartCoroutine(LoadCoroutine(sceneName));
    }
}
