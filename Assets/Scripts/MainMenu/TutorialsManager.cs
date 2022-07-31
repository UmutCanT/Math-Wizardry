using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsManager : MonoBehaviour
{
    [SerializeField] GameObject[] Panels;

    void OnEnable()
    {
        foreach (GameObject item in Panels)
        {
            item.SetActive(false);
        }
        Panels[0].SetActive(true);
    }
}
