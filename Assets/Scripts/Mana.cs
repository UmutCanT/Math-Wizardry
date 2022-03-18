using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public event Action onManaChange;

    int totalManaPool = 8;
    int currentMana;
    const int manaGainAmount = 1;

    public int CurrentMana { get => currentMana; set => currentMana = value; }

    void Awake()
    {
        currentMana = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Answering>().onBonusGain += ManaGain;
    }

    void ManaGain()
    {
        if (currentMana < totalManaPool)
        {
            currentMana += manaGainAmount;
            onManaChange();
        }      
    }
}
