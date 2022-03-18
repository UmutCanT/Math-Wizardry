using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Text healthText;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<Player>().GetComponent<Health>();
        HealthUIUpdate();
        health.onHealthChange += HealthUIUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HealthUIUpdate()
    {
        healthText.text = health.CurrentHealth.ToString();
    }
}
