using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EssenceUI : MonoBehaviour
{
    public void SetAnswer(string text)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public int GetAnswer()
    {
        return int.Parse(gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
    }
}
