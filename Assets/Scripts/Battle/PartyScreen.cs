using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartyScreen : MonoBehaviour
{
    [SerializeField] Text messageText;

    PartyMember[] memberSlots;

    public void Init()
    {
        memberSlots = GetComponentsInChildren<PartyMember>();

    }

    public void SetPartyData(List<Pokemon> pokemons)
    {
        for(int i=0;i<memberSlots.Length;i++)
        {
            if(i <pokemons.Count)
                memberSlots[i].SetData(pokemons[i]);
            else
                memberSlots[i].gameObject.SetActive(false);
        }
        messageText.text = "Choose a pokemon to fight!";
    }
}


