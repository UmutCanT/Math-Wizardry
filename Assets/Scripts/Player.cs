using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ability ability;
    void Awake()
    {
        gameObject.AddComponent<Health>();
        gameObject.AddComponent<Mana>();
    }

    public void IntializeAbility(Ability selectedAbility)
    {
        ability = selectedAbility;
        ability.Initialize(gameObject);
    }
    void OnMouseDown()
    {
        ability.TriggerAbility();
    }
}
