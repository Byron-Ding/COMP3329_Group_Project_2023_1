using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;


public class FightText : TextBasic {
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
        // 先暂时取消所有脚本和Text组件的绑定
        Text fightText = dialogBox.actionTexts_public[0];
        Destroy(fightText.GetComponent<FightText>());
        Text runText = dialogBox.actionTexts_public[1];
        Destroy(runText.GetComponent<RunText>());


        Debug.Log("Fight");
        //Fight
        battleSystem.PlayerMove();
    }

}
