using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action onHealthChange;

    int totalHealth;
    int currentHealth;
    const int damageAmount = 1;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Awake()
    {
        totalHealth = 10;
        currentHealth = totalHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Answering>().onWrongAnswer += Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage()
    {
        currentHealth -= damageAmount;
        onHealthChange();
    }
}
