using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToNextScence : StartPageButtonBase
{
    // 按下空格就切换到下个场景


    // 按下鼠标左键切换下个场景
    public override void MouseButtonLeftClick() {
        // 切换到下个场景
        // 1. 获取当前场景的序号
        int currentScenceIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        // 2. 切换到下个场景
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScenceIndex + 1);
    }
}
