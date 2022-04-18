using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPref : MonoBehaviour
{
    public static SelectedPref Instance { get; private set; }
    static Character selectedCharacter;

    public Character SelectedCharacter { get => selectedCharacter; set => selectedCharacter = value; }

    void Awake()
    {  
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }         
    }
}
