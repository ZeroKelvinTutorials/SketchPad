using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//allows the use of File class
using System.IO;

public class FileManager : MonoBehaviour
{
    public InputField fileNameInputField;

    public void Save()
    {
        string fileName = fileNameInputField.text;
        string filePath = Application.dataPath + "/" + fileName + ".txt";

        SaveFile newSaveFile = new SaveFile(TouchDraw.drawnLineRenderers);
        string jsonString = JsonUtility.ToJson(newSaveFile);
        File.WriteAllText(filePath,jsonString);
    }

    public void Load()
    {
        string fileName = fileNameInputField.text;
        string filePath = Application.dataPath + "/" + fileName + ".txt";

        if(File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            SaveFile newSaveFile = JsonUtility.FromJson<SaveFile>(jsonString);
            newSaveFile.Draw();
        }
        else
        {
            Debug.Log("No savefile with that name");
        }
    }
}
