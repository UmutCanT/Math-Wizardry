using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EssenceUI : MonoBehaviour
{
    public void Answer(string text)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
