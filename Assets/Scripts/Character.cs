using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character")]
public class Character : ScriptableObject
{
    [SerializeField] string characterName = "Name";
    [SerializeField] int totalHealth = 10;    

    [SerializeField] Ability[] abilites;

    public int TotalHealth { get => totalHealth; }
    public Ability[] Abilites { get => abilites; set => abilites = value; }
}
