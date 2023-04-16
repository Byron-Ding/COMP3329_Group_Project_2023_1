using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillText_1 : TextBasic, SkillTextInterface {
    [SerializeField] BattleDialogbox dialogBox;
    [SerializeField] BattleSystem battleSystem;

    public int skillID {
        get { return 1; }
        set {
            skillID = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ButtonLeftClick() {
        // 先暂时关闭 所有和Text组件的绑定的脚本
        Text skillText1 = dialogBox.moveTexts_public[0];
        skillText1.GetComponent<SkillText_1>().enabled = false;
        Text skillText2 = dialogBox.moveTexts_public[1];
        skillText2.GetComponent<SkillText_2>().enabled = false;
        Text skillText3 = dialogBox.moveTexts_public[2];
        skillText3.GetComponent<SkillText_3>().enabled = false;
        Text skillText4 = dialogBox.moveTexts_public[3];
        skillText4.GetComponent<SkillText_4>().enabled = false;

        // 直接传入技能ID
        battleSystem.currentMove = skillID;

        // 照常执行
        // 传入技能ID后，更新技能选择框
        dialogBox.UpdateMoveSelection(battleSystem.currentMove);

        // 禁用技能选择框，启用对话框
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        // 执行技能
        StartCoroutine(battleSystem.PerformPlayerMove());

    }
}
