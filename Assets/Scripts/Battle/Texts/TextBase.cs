using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TextBasic : MonoBehaviour, IPointerClickHandler {
    

    // 左中右点击事件
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;


    private void Start() {
        leftClick.AddListener(new UnityAction(ButtonLeftClick));
        middleClick.AddListener(new UnityAction(ButtonMiddleClick));
        rightClick.AddListener(new UnityAction(ButtonRightClick));
    }

    /*
     * 点击事件函数
     */
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            middleClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }


    private void ButtonLeftClick() {
    }

    private void ButtonMiddleClick() {
    }

    private void ButtonRightClick() {
    }

}
