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
        // ����ʱȡ�����нű���Text����İ�
        Text skillText1 = dialogBox.moveTexts_public[0];
        Destroy(skillText1.GetComponent<SkillText_1>());
        Text skillText2 = dialogBox.moveTexts_public[1];
        Destroy(skillText2.GetComponent<SkillText_2>());
        Text skillText3 = dialogBox.moveTexts_public[2];
        Destroy(skillText3.GetComponent<SkillText_3>());
        Text skillText4 = dialogBox.moveTexts_public[3];
        Destroy(skillText4.GetComponent<SkillText_4>());

        // ֱ�Ӵ��뼼��ID
        battleSystem.currentMove = skillID;

        // �ճ�ִ��
        // ���뼼��ID�󣬸��¼���ѡ���
        dialogBox.UpdateMoveSelection(battleSystem.currentMove);

        // ���ü���ѡ������öԻ���
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        // ִ�м���
        StartCoroutine(battleSystem.PerformPlayerMove());

    }
}
