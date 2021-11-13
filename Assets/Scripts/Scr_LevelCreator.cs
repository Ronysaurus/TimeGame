using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Scr_LevelCreator : MonoBehaviour
{
    JsonData jsonData;

    public GameObject normalTile;

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
            switch (int.Parse(jsonData["Tiles"][i]["Type"].ToString()))
            {
                case 0:
                    {
                        GameObject.Instantiate(normalTile, new Vector3(float.Parse(jsonData["Tiles"][i]["posX"].ToString()), float.Parse(jsonData["Tiles"][i]["posY"].ToString())), Quaternion.identity);
                        break;
                    }
            }
        }
    }
}
