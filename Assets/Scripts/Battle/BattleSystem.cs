using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;

    [SerializeField] BattleDialogbox dialogBox;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    public event Action<bool> OnBattleOver;

    BattleState state;
    int currentAction;  
    public int currentMove;

    public void StartBattle()
    {
        StartCoroutine(SetupBattle());
        //SetupBattle();
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();  
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        dialogBox.SetMoveNames(playerUnit.Pokemon.Moves);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");

        //StartCoroutine( dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared."));
        //dialogBox.SetDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }
    
    public void PlayerAction()
    {
        state = BattleState.PlayerAction;

        StartCoroutine(dialogBox.TypeDialog("Choose an action"));

        dialogBox.EnableActionSelector(true);

    }

    public void PlayerMove()
    {
        state = BattleState.PlayerMove;

        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

<<<<<<< Updated upstream
    /**
     * 执行攻击动作
     * 
     */
=======
>>>>>>> Stashed changes
    public IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;

        var move = playerUnit.Pokemon.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} used {move.Base.Name}");

        playerUnit.PlayAttackAnimation();
        yield return new WaitForSeconds(1f);

        enemyUnit.PlayHitAnimation();
        bool isFainted = enemyUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return enemyHud.UpdateHP();
        if(isFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.Base.Name} Fainted");
            enemyUnit.PlayFaintAnimation();
            yield return new WaitForSeconds(1f);
            OnBattleOver(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;

        var move = enemyUnit.Pokemon.GetRandomMove();

        yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.Base.Name} used {move.Base.Name}");
        
        enemyUnit.PlayAttackAnimation();
        yield return new WaitForSeconds(1f);

        playerUnit.PlayHitAnimation();
        bool isFainted = playerUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return playerHud.UpdateHP();

        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} Fainted");
            playerUnit.PlayFaintAnimation();
            
            yield return new WaitForSeconds(1f);
            OnBattleOver(false);
        }
        else
        {
            PlayerAction();
        }
    }
    public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }

        else if(state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }

    }
    void HandleActionSelection()
    {
<<<<<<< Updated upstream
        // 临时启用 actionTexts上的脚本
        // fight
        Text fightText = dialogBox.actionTexts_public[0];
        fightText.GetComponent<FightText>().enabled = true;
        // run
        Text runText = dialogBox.actionTexts_public[1];
=======
        // 开启关联脚本
        // 先暂时关闭 所有和Text组件的绑定的脚本
        Text fightText = actionTexts[0];
        fightText.GetComponent<FightText>().enabled = true;
        Text runText = actionTexts[1];
>>>>>>> Stashed changes
        runText.GetComponent<RunText>().enabled = true;


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
           
        } 
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentAction>0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);


        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            if(currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if(currentAction == 1)
            {
                //run
            }
        }
    }
    
    void HandleMoveSelection() {
<<<<<<< Updated upstream
        // 绑定临时点击事件到moveTexts上
        Text skillText1 = dialogBox.moveTexts_public[0];
        skillText1.GetComponent<SkillText_1>().enabled = true;
        Text skillText2 = dialogBox.moveTexts_public[1];
        skillText2.GetComponent<SkillText_2>().enabled = true;
        Text skillText3 = dialogBox.moveTexts_public[2];
        skillText3.GetComponent<SkillText_3>().enabled = true;
        Text skillText4 = dialogBox.moveTexts_public[3];
        skillText4.GetComponent<SkillText_4>().enabled = true;


=======
        // 开启关联脚本 所有和Text组件的绑定的脚本
        Text skillText1 = moveTexts[0];
        skillText1.GetComponent<SkillText_1>().enabled = true;
        Text skillText2 = moveTexts[1];
        skillText2.GetComponent<SkillText_2>().enabled = true;
        Text skillText3 = moveTexts[2];
        skillText3.GetComponent<SkillText_3>().enabled = true;
        Text skillText4 = moveTexts[3];
        skillText4.GetComponent<SkillText_4>().enabled = true;

>>>>>>> Stashed changes
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count -1)
                currentMove++;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                currentMove--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 2)
                currentMove += 2;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
                currentMove -= 2;
        }
        dialogBox.UpdateMoveSelection(currentMove);



        if(Input.GetKeyDown(KeyCode.Space))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
