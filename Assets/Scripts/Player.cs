using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStatus[] playerStatuses;
    [SerializeField] Animator animator;
    Ability ability;

    bool ableToCast;

    void Start()
    {
        Answering.OnAnswer += AllowCast;
        Health.OnHealthDepleted += StopCasting;
        Answering.OnCorrectAnswer += OnCorrectEffect;
        Answering.OnWrongAnswer += OnWrongEffect;
        Health.OnHeal += OnHealEffect;
        
        AllowCast();    
    }

    public void IntializeAbility(Ability selectedAbility)
    {
        ability = selectedAbility;
        ability.Initialize(gameObject);
    }

    void OnCorrectEffect()
    {
        StartCoroutine(ActivateEffect(PlayerStatusTypes.AnsweringCorrect));
    }

    void OnWrongEffect()
    {
        StartCoroutine(ActivateEffect(PlayerStatusTypes.AnsweringWrong));
    }

    void OnHealEffect()
    {
        StartCoroutine(ActivateEffect(PlayerStatusTypes.Healing));
    }

    IEnumerator ActivateEffect(PlayerStatusTypes type)
    {
        foreach (PlayerStatus status in playerStatuses)
        {
            if (status.type == type)
            {
                status.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                status.gameObject.SetActive(false);
            }
        }      
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
        Answering.OnCorrectAnswer -= OnCorrectEffect;
        Answering.OnWrongAnswer -= OnWrongEffect;
        Health.OnHeal -= OnHealEffect;
    }
}
