using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] Character[] characters;

    public void OnCharacterSelect(int characterID) 
    {
        SelectedPref.Instance.SelectedCharacter = characters[characterID];
    }
}
