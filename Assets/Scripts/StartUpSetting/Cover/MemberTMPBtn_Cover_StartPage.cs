using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemberTMPBtn_Cover_StartPage : StartPageButtonBase
{
    public TextMeshProUGUI TextBtnSelf;

    // Start is called before the first frame update
    public override void Start() {
        base.Start();

    }

    // Update is called once per frame
    public override void Update() {
        base.Update();

    }

    // 改变文字
    public void ChangeText() {
        // 获取文字
        string text = TextBtnSelf.text;
        
        // 改变文字
        if (text == Data_StartPage.MEMBER_TMPBTN_ORIGIN_COVER_START_PAGE) {
            TextBtnSelf.text = Data_StartPage.MEMBER_TMPBTN_MEMBER_NAME_COVER_START_PAGE;

        }else if (text == Data_StartPage.MEMBER_TMPBTN_MEMBER_NAME_COVER_START_PAGE) {
            TextBtnSelf.text = Data_StartPage.MEMBER_TMPBTN_ORIGIN_COVER_START_PAGE;
        }
    }


    // 鼠标左键点击，改变文字为指定内容
    public override void MouseButtonLeftClick() {
        base.MouseButtonLeftClick();

        // 改变文字
        ChangeText();
    }

    
}
