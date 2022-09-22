using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;

public class GetCards : MonoBehaviour
{
    [SerializeField] GameObject cardPref;
    [SerializeField] TMP_InputField cardName;
    [SerializeField] TMP_Dropdown type;
    [SerializeField] TMP_Dropdown rarity;
    [SerializeField] TMP_InputField minHealth;
    [SerializeField] TMP_InputField maxHealth;
    Pokemon card;
    Dictionary<string, string> list = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        list.Add("name", "ape");
        l();        
    }

    //clear the card list
    public void ClearList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void search()
    {
        list.Clear();
        ClearList();
        if (!string.IsNullOrEmpty(cardName.text))
        {
            Debug.Log("got text");
            list.Add("name", cardName.text);
        }
        if (type.options[type.value].text != null)
        {
            list.Add("ypes", type.options[type.value].text);
        }
        if (rarity.options[rarity.value].text != null)
        {
            list.Add("rarity", rarity.options[rarity.value].text);
        }
        if (!string.IsNullOrEmpty(minHealth.text) || !string.IsNullOrEmpty(maxHealth.text))
        {
            list.Add("hp", minHealth.text + "" + maxHealth.text);
        }
        if (list.Count == 0)
        {
            list.Add("name", "geo");
        }
        l();
    }

    // get a list of cards according to the list parameters
    async void l()
    {
        card = await Card.GetAsync(list);
        Debug.Log(card.Cards.Count);
        foreach (PokemonCard card in card.Cards)
        {
            Debug.Log(card.Name);
            GameObject go = Instantiate(cardPref, transform);
            go.GetComponent<CardPref>().getinfo(card);
        }
    }
}
