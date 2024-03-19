using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class HighlightText : MonoBehaviour
{
    public Button[] buttons;

    public void IncreaseOutlineWidth(int index)
    {
        buttons[index].GetComponentInChildren<TMP_Text>().outlineWidth = 0.2f;
    }
    public void DecreaseOutlineWidth(int index)
    {
        buttons[index].GetComponentInChildren<TMP_Text>().outlineWidth = 0;
    }
}
