using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy, PartyScreen, BattleOver }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] PartyScreen partyScreen;
    [SerializeField] BattleDialogbox dialogBox;

    public event Action<bool> OnBattleOver;

    BattleState state;
    int currentAction;  
    int currentMove;
    int currentMember;

    PokemonParty playerParty;
    Pokemon wildPokemon;
    public void StartBattle(PokemonParty playerParty, Pokemon wildPokemon)
    {
        this.playerParty = playerParty; 
        this.wildPokemon = wildPokemon; 

        StartCoroutine(SetupBattle());
        //SetupBattle();
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup(playerParty.GetHealthyPokemon());
        enemyUnit.Setup(wildPokemon);  
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        partyScreen.Init();

        dialogBox.SetMoveNames(playerUnit.Pokemon.Moves);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");

        //StartCoroutine( dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared."));
        //dialogBox.SetDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void BattleOver(bool won)
    {
        state = BattleState.BattleOver;

        OnBattleOver(won);      
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;

        StartCoroutine(dialogBox.TypeDialog("Choose an action"));

        dialogBox.EnableActionSelector(true);

    }
    void OpenPartyScreen()
    {
        state = BattleState.PartyScreen;

        partyScreen.SetPartyData(playerParty.Pokemons);
        partyScreen.gameObject.SetActive(true); 
        //
    }
    void PlayerMove()
    {
        state = BattleState.PlayerMove;

        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
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

            int expYield = enemyUnit.Pokemon.Base.ExpYield;
            int enemyLevel = enemyUnit.Pokemon.Level;

            int expGain = Mathf.FloorToInt((expYield * enemyLevel) / 5);

            playerUnit.Pokemon.Exp += expGain;

            yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} gained {expGain} exp");

            yield return playerHud.SetExpSmooth();


            yield return new WaitForSeconds(2f);

            while(playerUnit.Pokemon.CheckForLevelUp())
            {
                playerHud.SetLevel();
                yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} level up to Lvl{playerUnit.Pokemon.Level}!");
                yield return playerHud.SetExpSmooth(true);
            }
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
            var nextPokemon = playerParty.GetHealthyPokemon();  

            if(nextPokemon != null) {
                OpenPartyScreen();

            }
            else
            {
                OnBattleOver(false);
            }
            
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
        else if (state == BattleState.PartyScreen)
        {
            HandlePartyScreenSelection();

        }
        else if(state == BattleState.BattleOver)
        {
            TryToEscape();
        }

    }
    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAction < 3)
                currentAction++;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAction > 0)
                currentAction--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 2)
                currentAction += 2;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 1)
                currentAction -= 2;
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
                OpenPartyScreen();
                // Capture
            }
            else if (currentAction == 2)
            {
                // Pokemon
                
            }
            else if (currentAction == 3)
            {
                BattleOver(true);
                // Run
            }
        }
    }
    
    void HandleMoveSelection()
    {
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            PlayerAction();
        }
    }

    void HandlePartyScreenSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMember < playerParty.Pokemons.Count-1)
                currentMember++;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMember > 0)
                currentMember--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMember < playerParty.Pokemons.Count - 2)
                currentMember += 2;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMember > 1)
                currentMember -= 2;
        }

        partyScreen.UpdateMemberSelection(currentMember);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var selectedMember = playerParty.Pokemons[currentMember];

            if(selectedMember.HP<=0)
            {
                partyScreen.SetMessageText("You can't send out a fainted pokemon!");
                return;
            }
            if(selectedMember == playerUnit.Pokemon)
            {
                partyScreen.SetMessageText("You can't switch with the same pokemon!");
                return;
            }
            partyScreen.gameObject.SetActive(false);
            state = BattleState.Busy;
            StartCoroutine(SwitchPokemon(selectedMember));
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            partyScreen.gameObject.SetActive(false);
            PlayerAction();
        }
    }

    IEnumerator SwitchPokemon(Pokemon newPokemon)
    {

        if(playerUnit.Pokemon.HP >0)
        {
            yield return dialogBox.TypeDialog($"Come back {playerUnit.Pokemon.Base.Name}");
            playerUnit.PlayFaintAnimation();

            yield return new WaitForSeconds(1f);
        }

        
        playerUnit.Setup(newPokemon);
        playerHud.SetData(newPokemon);

        dialogBox.SetMoveNames(newPokemon.Moves);

        yield return dialogBox.TypeDialog($"Go {newPokemon.Base.Name}!");
        StartCoroutine(EnemyMove());
    }
    IEnumerator TryToEscape()
    {
        state = BattleState.Busy;

        yield return dialogBox.TypeDialog($"Run away safely!");

        OnBattleOver(false);
    }
}
