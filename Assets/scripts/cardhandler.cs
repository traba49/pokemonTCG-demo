using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using TMPro;

public class cardhandler : MonoBehaviour
{
    [SerializeField] Transform deck;
    [SerializeField] GameObject cardpref;
    [SerializeField] TMP_InputField savename;
    [SerializeField] string[] decklist = new string[30];
    int i;
    Pokemon card;
    // Start is called before the first frame update
    private void Start()
    {
        i = 0;
    }
    public async void loaddeck(string[] deckli)
    {
        
        decklist = deckli;
        for (int j=0; j < decklist.Length; j++)
        {
            if(!string.IsNullOrEmpty(decklist[j])) 
            {
                card = await Card.FindAsync<Pokemon>(decklist[j]);
                i = j; 
                GameObject go = Instantiate(cardpref, deck);
                go.GetComponent<cardpref>().getinfo(card.Card);
            }

        }
    }

    // add a card to the deck
    public void addcard(PokemonCard card)
    {
        if (string.IsNullOrEmpty(decklist[i]))
        {
            GameObject go = Instantiate(cardpref, deck);
            go.GetComponent<cardpref>().getinfo(card);
            decklist[i] = card.Id;
            do
            {
                i++;
            }while (!string.IsNullOrEmpty(decklist[i]) && i < decklist.Length);
        }
        else
        {
            Debug.LogWarning("Deck is full");
        }
        
    }

    public void removecard(GameObject card, string id)
    {
        for (int j = 0; j <= decklist.Length; j++)
        {
            if(id == decklist[j]) 
            { 
                decklist[j] = null; 
                i = j;
                break;
            }
        }
        Destroy(card);
    }

    public void cleardeck()
    {
        for (int j = 0; j <= decklist.Length; j++)
        {
            decklist[j] = null;
        }
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void savedeck()
    {
        if (!string.IsNullOrEmpty(savename.text))
        {
            savedata data = new savedata();
            data.deckList = decklist;
            data.deckname = savename.text;
            savingsystem.Savegame(data, savename.text);
        }
        else
        {
            Debug.LogError("savename empty");
        }
    }
}
