using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnHealthChange;
    public static event Action OnHealthDepleted;
    public static event Action OnRegress;
    public static event Action OnHeal;

    int currentHealth;
    int maxHealth;
    const int damageAmount = 1;
    int damageCounter;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; 
        set {
            maxHealth = value;
            currentHealth = maxHealth;
        }  
    }

    // Start is called before the first frame update
    void Start()
    {
        damageCounter = 0;
        Answering.OnWrongAnswer += Damage;
    }

    public bool CanHeal()
    {
        return currentHealth < maxHealth;
    }

    public void Heal()
    {
        OnHeal();
        currentHealth += 1;
        OnHealthChange();
    }

    void Damage()
    {
        damageCounter++;
        currentHealth -= damageAmount;        
        OnHealthChange();
        if (damageCounter >= 2)
        {
            OnRegress();
            damageCounter = 0;
        }
        if (currentHealth <= 0)
        {
            OnHealthDepleted();
        }
    }

    void OnDisable()
    {
        Answering.OnWrongAnswer -= Damage;
    }
}
