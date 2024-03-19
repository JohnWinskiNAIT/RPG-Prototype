using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileMethods2 : MonoBehaviour
{
    [SerializeField]
    InputField nameField;
    [SerializeField]
    Dropdown optionDrop;
    [SerializeField]
    Toggle yesno;

    private void Start()
    {
        nameField.text = GetPlayerName();
        optionDrop.value = GetOption();
        yesno.isOn = GetToggle();
    }

    public void ChangePlayerName(string n)
    {
        GameManager2.playerName = n;
    }
    public void ChangeOption(int op)
    {
        GameManager2.option = op;
    }

    public void ChangeToggle(bool b)
    {
        GameManager2.toggle = b;
    }

    public string GetPlayerName()
    {
        return GameManager2.playerName;
    }

    public int GetOption()
    {
        return GameManager2.option;
    }

    public bool GetToggle()
    {
        return GameManager2.toggle;
    }
}
