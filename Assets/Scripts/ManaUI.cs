using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    [SerializeField] Text manaText;
    Mana mana;

    // Start is called before the first frame update
    void Start()
    {
        mana = FindObjectOfType<Player>().GetComponent<Mana>();
        ManaUIUpdate();
        mana.onManaChange += ManaUIUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ManaUIUpdate()
    {
        manaText.text = mana.CurrentMana.ToString();
    }
}
