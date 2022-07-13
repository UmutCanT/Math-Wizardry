using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    [SerializeField] MeterScript manaPool;
    Mana mana;

    // Start is called before the first frame update
    void Start()
    {
        mana = FindObjectOfType<Player>().GetComponent<Mana>();
        manaPool.SetMaxMana(mana.TotalManaPool);
        ManaUIUpdate();
        mana.OnManaChange += ManaUIUpdate;
    }

    void ManaUIUpdate()
    {
        manaPool.SetMana(mana.CurrentMana);
    }

    void OnDisable()
    {
        mana.OnManaChange -= ManaUIUpdate;
    }
}
