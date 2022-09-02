using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PokemonTcgSdk.Models;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class cardpref : MonoBehaviour
{
    [SerializeField] Image image;

    private PokemonCard card;
    private showHighResCard highRes;
    private cardhandler deck;
    private AudioSource source;
    // Start is called before the first frame update
    private void Start()
    {
        highRes = FindObjectOfType<showHighResCard>();
        deck = FindObjectOfType<cardhandler>();
        source = FindObjectOfType<AudioSource>();

        //event trigger setup
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { source.Play(); });
        trigger.triggers.Add(entry);
        //end of setup
    }

    //add the card to the deck or remove it from the deck
    public void addcard()
    {
        if (transform.parent.CompareTag("list"))
        {
            deck.addcard(card);
        }
        else if (transform.parent.CompareTag("deck"))
        {
            deck.removecard(gameObject,card.Id);
        }
        else
        {
            Debug.LogError("Tag not found");
        }
        
    }

    //display and hide the card's High resolution image
    public void sendimage()
    {
        highRes.showimage(card);
    }
    public void hideImage()
    {
        highRes.hideimage();
    }

    // get the card's information and display it
    public void getinfo(PokemonCard info)
    {
        card = info;
        StartCoroutine(GetRequest(info.ImageUrl));
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogWarning(request.error);
            yield break;
        }

        var texture = DownloadHandlerTexture.GetContent(request);
        var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.one * 0.5f);
        image.sprite = sprite;
    }
}
