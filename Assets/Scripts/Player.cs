using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ability ability;

    bool ableToCast;
    void Awake()
    {
        gameObject.AddComponent<Health>();
        gameObject.AddComponent<Mana>();
    }
    void Start()
    {
        GetComponent<Answering>().OnAnswer += CastStatus;
        CastStatus();    
    }

    public void IntializeAbility(Ability selectedAbility)
    {
        ability = selectedAbility;
        ability.Initialize(gameObject);
    }

    void OnMouseDown()
    {
        if (ableToCast)
        {
            ability.TriggerAbility();
            ableToCast = false;
        }        
    }

    void CastStatus()
    {
        ableToCast = true;
    }
}
