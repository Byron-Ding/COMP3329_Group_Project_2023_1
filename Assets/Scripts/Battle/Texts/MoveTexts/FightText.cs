using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.EventSystems;
>>>>>>> Stashed changes
using UnityEngine.UI;


public class FightText : TextBasic {
    [SerializeField] BattleDialogbox dialogBox;
    [SerializeField] BattleSystem battleSystem;

<<<<<<< Updated upstream
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
        Text fightText = dialogBox.actionTexts_public[0];
        Destroy(fightText.GetComponent<FightText>());
        Text runText = dialogBox.actionTexts_public[1];
        Destroy(runText.GetComponent<RunText>());
=======
    [SerializeField] List<Text> actionTexts;

    private void ButtonLeftClick() {
        // 先暂时关闭 所有和Text组件的绑定的脚本
        Text fightText = actionTexts[0];
        fightText.GetComponent<FightText>().enabled= false;
        Text runText = actionTexts[1];
        runText.GetComponent<RunText>().enabled = false;
>>>>>>> Stashed changes


        Debug.Log("Fight");
        //Fight
        battleSystem.PlayerMove();
    }

}
