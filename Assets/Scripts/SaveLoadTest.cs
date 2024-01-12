using System;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System.Reflection;

public class SaveLoadTest : MonoBehaviour
{
    [SerializeField]
    NameData myName;

    [SerializeField]
    TMP_InputField myInputField;

    [SerializeField]
    Button saveButton;

    [SerializeField]
    Button[] profileButtons;

    string filePath = "SaveData\\";
    int selectedProfile;

    // Start is called before the first frame update
    void Start()
    {
        myName = new NameData();

        LoadProfile();
    }

    private void Update()
    {
        if (selectedProfile == 0)
        {
            saveButton.interactable = false;
        }
        else
        {
            saveButton.interactable = true;
        }
    }

    public void ChangeName(string newName)
    {
        myName.playerName = newName;
    }

    public void LoadProfile()
    {
        SaveManager.LoadData(filePath +"\\PlayerData.sav", ref myName);

        myInputField.text = myName.playerName;
    }

    public void SaveProfile()
    {
        string profileName = myInputField.text;

        if (profileName != null)
        {
            filePath = "SaveData\\" + profileName; ;
        }

        CreateFileStructure();

        SaveManager.SaveData(filePath + "\\PlayerData.sav", ref myName);

        profileButtons[selectedProfile - 1].GetComponentInChildren<TMP_Text>().text = myInputField.text;
    }

    void CreateFileStructure()
    {
        // Determine whether the directory exists.
        if (Directory.Exists(filePath))
        {
            Debug.Log("Folder structure already exists");
        }
        else
        {
            // Try to create the directory.
            Directory.CreateDirectory(filePath);
        }
    }

    public void SelectProfile(int index)
    {
        selectedProfile = index;

        string profileName = profileButtons[index - 1].GetComponentInChildren<TMP_Text>().text;

        if (profileButtons[index - 1].GetComponentInChildren<TMP_Text>().text != "Empty")
        {
            filePath = "SaveData\\" + profileName;
        }
        
        LoadProfile();
    }
}