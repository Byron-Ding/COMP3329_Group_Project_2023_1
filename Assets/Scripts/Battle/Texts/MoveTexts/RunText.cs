using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunText : TextBasic {
    [SerializeField] BattleDialogbox dialogBox;
    [SerializeField] BattleSystem battleSystem;
    

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
        /*
        Text fightText = dialogBox.actionTexts_public[0];
        fightText.GetComponent<FightText>().enabled = false;
        Text runText = dialogBox.actionTexts_public[1];
        runText.GetComponent<RunText>().enabled = false;
        */
    }
}
