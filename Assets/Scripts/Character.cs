using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character")]
public class Character : ScriptableObject
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] string characterName = "Name";
    [SerializeField] int totalHealth = 10;
    [SerializeField] Sprite sprite;
    [SerializeField] RuntimeAnimatorController animController;

    [SerializeField] Ability[] abilites;

    public int TotalHealth { get => totalHealth; }
    public Ability[] Abilites { get => abilites; set => abilites = value; }
    public GameObject PlayerPrefab { 
        get {
            playerPrefab.GetComponent<SpriteRenderer>().sprite = sprite;
            playerPrefab.GetComponent<Animator>().runtimeAnimatorController = animController;
            return playerPrefab; 
        } 
    }
}
