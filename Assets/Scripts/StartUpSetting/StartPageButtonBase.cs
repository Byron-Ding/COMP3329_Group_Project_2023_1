using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartPageButtonBase : MonoBehaviour, IPointerClickHandler {


    // �����ҵ���¼�
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;



    // Start is called before the first frame update
    public virtual void Start() {
        leftClick.AddListener(new UnityAction(MouseButtonLeftClick));
        middleClick.AddListener(new UnityAction(MouseButtonMiddleClick));
        rightClick.AddListener(new UnityAction(MouseButtonRightClick));
    }

    // Update is called once per frame
    public virtual void Update() {

    }

    /*
     * ����¼�����
     */
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            middleClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }


    // ��װ����������
    public virtual void MouseButtonLeftClick() {
    }

    public virtual void MouseButtonMiddleClick() {
    }

    public virtual void MouseButtonRightClick() {
    }
}
