using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character")]
public class Character : ScriptableObject
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] string magicType = "Name";
    [SerializeField] int totalHealth = 10;
    [SerializeField] int totalMana = 10;
    [SerializeField] Sprite sprite;
    [SerializeField] RuntimeAnimatorController animController;
    [SerializeField] Ability[] abilites;
    //0-Frame, 1-Mask, 2-Fill, 3-Case
    [SerializeField] Sprite[] characterUI;
    [SerializeField] Gradient magicColor;

    public int TotalHealth { get => totalHealth; }
    public int TotalMana { get => totalMana; }
    public Sprite[] CharacterUI { get => characterUI; }
    public Gradient MagicColor { get => magicColor; }
    public Ability[] Abilites { get => abilites; set => abilites = value; }
    public GameObject PlayerPrefab { 
        get {
            playerPrefab.GetComponent<SpriteRenderer>().sprite = sprite;
            playerPrefab.GetComponent<Animator>().runtimeAnimatorController = animController;
            return playerPrefab; 
        } 
    }  
}
