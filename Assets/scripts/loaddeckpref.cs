using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class loaddeckpref : MonoBehaviour
{
    private AudioSource source;
    private gotodeckbuilder gtdb;
    private cardhandler handler;
    public TextMeshProUGUI text;

    private string[] decklist;
    // Start is called before the first frame update
    void Start()
    {
        source = FindObjectOfType<AudioSource>();
        gtdb = FindObjectOfType<gotodeckbuilder>();
        handler = FindObjectOfType<cardhandler>();
        //text = GetComponentInChildren<TextMeshProUGUI>();

        GetComponent<Button>().onClick.AddListener(gtdb.gotoscreen);

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
        handler.loaddeck(decklist);
    }

    //get the deck
    public void getdeck(string[] deck,string name)
    {
        decklist = deck;
        text.text = name;
    }
}
