using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LoadDeckPref : MonoBehaviour
{
    private AudioSource source;
    private GotoDeckBuilder _gotoDeckBuilder;
    private CardHandler handler;
    public TextMeshProUGUI text;

    private string[] deckList;
    // Start is called before the first frame update
    void Start()
    {
        source = FindObjectOfType<AudioSource>();
        _gotoDeckBuilder = FindObjectOfType<GotoDeckBuilder>();
        handler = FindObjectOfType<CardHandler>();
        //text = GetComponentInChildren<TextMeshProUGUI>();

        GetComponent<Button>().onClick.AddListener(_gotoDeckBuilder.gotoscreen);

        //event trigger setup
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { source.Play(); });
        trigger.triggers.Add(entry);
        //end of setup
    }

    // send the deck to the card handler for display 
    public void loaddeck()
    {
        handler.LoadDeck(deckList);
    }

    //get the deck
    public void getdeck(string[] deck,string name)
    {
        deckList = deck;
        text.text = name;
    }
}
