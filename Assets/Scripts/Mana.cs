using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public event Action OnManaChange;

    int totalMana = 0;
    int currentMana;
    const int manaGainAmount = 1;

    public int CurrentMana { get => currentMana; }
    public int TotalManaPool { get => totalMana; set => totalMana = value; }

    void Awake()
    {
        currentMana = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Answering.OnBonusGain += ManaGain;
    }

    public void ResetMana ()
    {
        currentMana = 0;
        OnManaChange();
    }

    void ManaGain()
    {
        if (currentMana < totalMana)
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
