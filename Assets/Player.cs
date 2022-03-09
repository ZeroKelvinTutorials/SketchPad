using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    
    [SerializeField] string playerName = "Zero Kelvin";
    [SerializeField] int currentHealth = 20;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Vector3 location = new Vector3(0,-273.15f,-459.67f);

    void Start()
    {
        GetAsJsonPrettyPrint();
    }
    string GetAsJson()
    {
        //will get json from public and serialized fields
        return JsonUtility.ToJson(this);
    }

    string GetAsJsonPrettyPrint()
    {
        File.WriteAllText(Application.dataPath + "/playerprettyprint.txt", JsonUtility.ToJson(this,true));
        return JsonUtility.ToJson(this,true);
    }

    void LoadFromJsonString(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, this);
    }
}
