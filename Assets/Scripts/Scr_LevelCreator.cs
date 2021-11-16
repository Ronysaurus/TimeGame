using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Scr_LevelCreator : MonoBehaviour
{
    JsonData jsonData;

    enum Tiles 
    {
        TNormal,
        TWall,
        TSwitch,
        TDoor,
         TEnd
    }

    public GameObject [] myTiles;

    private void Start()
    {
        ReadFile();
        Create();
    }

    void ReadFile()
    {
        StreamReader reader = new StreamReader("Assets/Resources/test.json");
        jsonData = JsonMapper.ToObject(reader.ReadToEnd());
        reader.Close();
    }

    void Create()
    {
        int numTiles = jsonData["Tiles"].Count;
        for (int i = 0; i < numTiles; i++)
        {
            GameObject tile =  GameObject.Instantiate(myTiles[int.Parse(jsonData["Tiles"][i]["Type"].ToString())], new Vector3(float.Parse(jsonData["Tiles"][i]["posX"].ToString()), float.Parse(jsonData["Tiles"][i]["posY"].ToString())), Quaternion.identity);
        }
    }
}
