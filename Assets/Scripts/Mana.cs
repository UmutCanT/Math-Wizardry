using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public event Action OnManaChange;

    readonly int totalManaPool = 8;
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
        Answering.OnBonusGain += ManaGain;
    }

    void ManaGain()
    {
        if (currentMana < totalManaPool)
        {
            currentMana += manaGainAmount;
            OnManaChange();
        }      
    }

    void OnDisable()
    {
        Answering.OnBonusGain -= ManaGain;
    }
}
