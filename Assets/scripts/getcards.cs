using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;

public class getcards : MonoBehaviour
{
    [SerializeField] GameObject cardpref;
    [SerializeField] TMP_InputField cardname;
    [SerializeField] TMP_Dropdown type;
    [SerializeField] TMP_Dropdown rarity;
    [SerializeField] TMP_InputField minhealth;
    [SerializeField] TMP_InputField maxhealth;
    Pokemon card;
    Dictionary<string, string> list = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        list.Add("name", "ape");
        l();        
    }

    //clear the card list
    public void clearlist()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void search()
    {
        list.Clear();
        clearlist();
        if (!string.IsNullOrEmpty(cardname.text))
        {
            Debug.Log("got text");
            list.Add("name", cardname.text);
        }
        if (type.options[type.value].text != null)
        {
            list.Add("ypes", type.options[type.value].text);
        }
        if (rarity.options[rarity.value].text != null)
        {
            list.Add("rarity", rarity.options[rarity.value].text);
        }
        if (!string.IsNullOrEmpty(minhealth.text) || !string.IsNullOrEmpty(maxhealth.text))
        {
            list.Add("hp", minhealth.text + "" + maxhealth.text);
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
            GameObject go = Instantiate(cardpref, transform);
            go.GetComponent<cardpref>().getinfo(card);
        }
    }
}
