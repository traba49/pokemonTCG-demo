using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class loadingSavedDecks : MonoBehaviour
{
    [SerializeField] Transform decks;
    [SerializeField] GameObject deckPref;
    // Start is called before the first frame update
    //find all saved decks and spawn a button for each of them
    void Start()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.testsave");
        foreach (string s in filePaths)
        {
            GameObject go = Instantiate(deckPref, decks);
            savedata data = savingsystem.Loadgame(s);
            go.GetComponent<loaddeckpref>().getdeck(data.deckList);
        }
    }

}
