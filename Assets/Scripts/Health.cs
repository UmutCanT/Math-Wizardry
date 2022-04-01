using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnHealthChange;

    int currentHealth;
    const int damageAmount = 1;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Answering>().OnWrongAnswer += Damage;
    }

    void Damage()
    {
        currentHealth -= damageAmount;
        OnHealthChange();
    }
}
