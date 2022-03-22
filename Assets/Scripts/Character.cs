using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character")]
public class Character : ScriptableObject
{
    [SerializeField] string characterName = "Name";
    [SerializeField] int totalHealth = 10;    

    [SerializeField] Ability quickAnswerAbility;
    [SerializeField] Ability ultimateAbility;

    public int TotalHealth { get => totalHealth; set => totalHealth = value; }
}
