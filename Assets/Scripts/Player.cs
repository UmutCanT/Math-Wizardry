using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Awake()
    {
        gameObject.AddComponent<Health>();
        gameObject.AddComponent<Mana>();
    }

    private void OnMouseDown()
    {
        
    }
}
