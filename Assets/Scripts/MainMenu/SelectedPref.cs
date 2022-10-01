using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPref : MonoBehaviour
{
    public static SelectedPref Instance { get; private set; }
    Character selectedCharacter;
    int selectedDifficulty;
    bool dynamicDifficulty;
    int selectedLocale;
    
    public Character SelectedCharacter { get => selectedCharacter; set => selectedCharacter = value; }
    public int SelectedDifficulty { get => selectedDifficulty; set => selectedDifficulty = value; }
    public bool DynamicDifficulty { get => dynamicDifficulty; set => dynamicDifficulty = value; }
    public int SelectedLocale { get => selectedLocale; set => selectedLocale = value; }

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
