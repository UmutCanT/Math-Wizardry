using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Animator animator;
    Ability ability;

    bool ableToCast;

    void Start()
    {
        Answering.OnAnswer += AllowCast;
        Health.OnHealthDepleted += StopCasting;
        AllowCast();    
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
            animator.SetTrigger("casting");
            ability.TriggerAbility();
            ableToCast = false;
        }        
    }

    void StopCasting()
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }

    void AllowCast()
    {       
        ableToCast = true;
    }

    void OnDisable()
    {
        Answering.OnAnswer -= AllowCast;
        Health.OnHealthDepleted -= StopCasting;      
    }
}
