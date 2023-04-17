using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillText_2 : TextBasic, SkillTextInterface {
    [SerializeField] BattleDialogbox dialogBox;
    [SerializeField] BattleSystem battleSystem;

<<<<<<< Updated upstream
=======
    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

>>>>>>> Stashed changes
    public int skillID {
        get { return 2; }
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
        // ����ʱ�ر� ���к�Text����İ󶨵Ľű�
<<<<<<< Updated upstream
        Text skillText1 = dialogBox.moveTexts_public[0];
        skillText1.GetComponent<SkillText_1>().enabled = false;
        Text skillText2 = dialogBox.moveTexts_public[1];
        skillText2.GetComponent<SkillText_2>().enabled = false;
        Text skillText3 = dialogBox.moveTexts_public[2];
        skillText3.GetComponent<SkillText_3>().enabled = false;
        Text skillText4 = dialogBox.moveTexts_public[3];
=======
        Text skillText1 = moveTexts[0];
        skillText1.GetComponent<SkillText_1>().enabled = false;
        Text skillText2 = moveTexts[1];
        skillText2.GetComponent<SkillText_2>().enabled = false;
        Text skillText3 = moveTexts[2];
        skillText3.GetComponent<SkillText_3>().enabled = false;
        Text skillText4 = moveTexts[3];
>>>>>>> Stashed changes
        skillText4.GetComponent<SkillText_4>().enabled = false;

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
