using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadingSavedDecks : MonoBehaviour
{
    [SerializeField] Transform decks;
    [SerializeField] GameObject deckPref;
    // Start is called before the first frame update    
    void Start()
    {
        loaddecks();
    }

    //find all saved decks and spawn a button for each of them
    public void loaddecks()
    {
        int i = decks.childCount;
        for (int j = 1; j < i; j++)
        {
            Destroy(decks.GetChild(j).gameObject);
        }

        string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.testsave");
        foreach (string s in filePaths)
        {
            GameObject go = Instantiate(deckPref, decks);
            SaveData data = SavingSystem.Loadgame(s);
            go.GetComponent<LoadDeckPref>().getdeck(data.deckList, data.deckName);
        }
    }

}
