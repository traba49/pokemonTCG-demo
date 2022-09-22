using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using TMPro;

public class CardHandler : MonoBehaviour
{
    [SerializeField] Transform deck;
    [SerializeField] GameObject cardPref;
    [SerializeField] TMP_InputField saveName;
    [SerializeField] string[] deckList = new string[30];
    int i;
    Pokemon card;
    // Start is called before the first frame update
    private void Start()
    {
        i = 0;
    }
    public async void LoadDeck(string[] deckli)
    {
        
        deckList = deckli;
        for (int j=0; j < deckList.Length; j++)
        {
            if(!string.IsNullOrEmpty(deckList[j])) 
            {
                card = await Card.FindAsync<Pokemon>(deckList[j]);
                i = j; 
                GameObject go = Instantiate(cardPref, deck);
                go.GetComponent<CardPref>().getinfo(card.Card);
            }

        }
    }

    // add a card to the deck
    public void AddCard(PokemonCard card)
    {
        if (string.IsNullOrEmpty(deckList[i]))
        {
            GameObject go = Instantiate(cardPref, deck);
            go.GetComponent<CardPref>().getinfo(card);
            deckList[i] = card.Id;
            do
            {
                i++;
            }while (!string.IsNullOrEmpty(deckList[i]) && i < deckList.Length);
        }
        else
        {
            Debug.LogWarning("Deck is full");
        }
        
    }

    public void RemoveCard(GameObject card, string id)
    {
        for (int j = 0; j <= deckList.Length; j++)
        {
            if(id == deckList[j]) 
            { 
                deckList[j] = null; 
                i = j;
                break;
            }
        }
        Destroy(card);
    }

    public void ClearDeck()
    {
        for (int j = 0; j <= deckList.Length; j++)
        {
            deckList[j] = null;
        }
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SaveDeck()
    {
        if (!string.IsNullOrEmpty(saveName.text))
        {
            SaveData data = new SaveData();
            data.deckList = deckList;
            data.deckName = saveName.text;
            SavingSystem.Savegame(data, saveName.text);
        }
        else
        {
            Debug.LogError("savename empty");
        }
    }
}
