using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Freedom, Battle, Dialog}
public class Gamecontroller : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    GameState state;

    private void Start()
    {
        playerController.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;

        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;

        };
        DialogManager.Instance.OnDialogFinished += () =>
        {

            if(state == GameState.Dialog)
            {
                state = GameState.Freedom;
            }
        };
    }
    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        var playerParty = playerController.GetComponent<PokemonParty>();    
        var wildPokemon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();

        battleSystem.StartBattle(playerParty,wildPokemon);
    }

    void EndBattle(bool won)
    {
        state = GameState.Freedom;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    private void Update()
    {
        if(state == GameState.Freedom) 
        {
            playerController.HandleUpdate();  
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
        else if( state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
    }
}
