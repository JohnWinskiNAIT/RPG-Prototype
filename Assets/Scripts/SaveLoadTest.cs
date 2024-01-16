using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveLoadTest : MonoBehaviour
{
    [SerializeField]
    NameData myName;

    [SerializeField]
    TMP_InputField myInputField;

    [SerializeField]
    Button[] profileButtons;

    [SerializeField]
    GameObject namePanel;

    [SerializeField]
    Button deleteButton;

    [SerializeField]
    CharacterData myChar;

    string rootPath = "SaveData\\";
    string filePath;
    int selectedProfile;

    // Start is called before the first frame update
    void Start()
    {
        myName = new NameData();

        UpdateProfileButtons();

        GameManager.currentChar.char_Name = myChar.char_Name;
    }

    public void ChangeName(string newName)
    {
        myName.playerName = newName;
        SaveProfile();
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
            namePanel.SetActive(false);
            
            filePath = rootPath + profileName;

            if (!Directory.Exists(filePath))
            {
                CreateFileStructure();

                SaveManager.SaveData(filePath + "\\PlayerData.sav", ref myName);

                profileButtons[selectedProfile - 1].GetComponentInChildren<TMP_Text>().text = myInputField.text;
            }
            else 
            {
                // TODO:: Add a modal panel to display this message.
                Debug.Log("Profile already exists");
            }
        }

        
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

    void UpdateProfileButtons()
    {
        DirectoryInfo di = new DirectoryInfo(rootPath);

        DirectoryInfo[] diArr = di.GetDirectories();

        for (int i = 0; i < diArr.Length && i < profileButtons.Length; i++)
        {
            profileButtons[i].GetComponentInChildren<TMP_Text>().text = diArr[i].Name;
        }
    }

    public void SelectProfile(int index)
    {
        selectedProfile = index;

        string profileName = profileButtons[index - 1].GetComponentInChildren<TMP_Text>().text;

        if (profileButtons[index - 1].GetComponentInChildren<TMP_Text>().text != "Empty")
        {
            namePanel.SetActive(false);
            deleteButton.interactable = true;
            filePath = rootPath + profileName;
            LoadProfile();
        }
        else
        {
            myInputField.text = null;
            namePanel.SetActive(true);
            deleteButton.interactable = false;

            EventSystem.current.SetSelectedGameObject(myInputField.gameObject, null);
        }
    }

    public void DeleteProfile()
    {
        if (Directory.Exists(filePath))
        {
            // Try to delete the directory.
            Directory.Delete(filePath, true);
            profileButtons[selectedProfile - 1].GetComponentInChildren<TMP_Text>().text = "Empty";
        }
    }
}