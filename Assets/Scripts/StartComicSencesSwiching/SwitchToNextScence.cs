using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToNextScence : StartPageButtonBase
{
    // ���¿ո���л����¸�����


    // �����������л��¸�����
    public override void MouseButtonLeftClick() {
        // �л����¸�����
        // 1. ��ȡ��ǰ���������
        int currentScenceIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        // 2. �л����¸�����
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScenceIndex + 1);
    }
}
