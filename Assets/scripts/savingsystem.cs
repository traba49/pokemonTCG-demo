using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem 
{       

    public static void Savegame(SaveData data,string savename)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + savename +".testsave";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Loadgame(string savename)
    {
        if (File.Exists(savename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savename, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            //Newgame();
            return null;
        }
    }
    
    //not in use
    static void Newgame()
    {
        SaveData data = new SaveData();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/rolling.testsave";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();

        //Loadgame();
    }
}

