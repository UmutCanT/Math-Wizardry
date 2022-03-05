using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use with this IObjectPool when Unity version upgraded 
public class EssencePool : MonoBehaviour
{
    public static EssencePool SharedInstance;

    private List<GameObject> essences = new List<GameObject>();

    [SerializeField] GameObject essencePrefab;
    int essenceCount = 4;

    Vector3 spawnPos = new Vector3(0, 5, 0);

    public List<GameObject> Essences { get => essences; set => essences = value; }

    void Awake()
    {
        SharedInstance = this;
        CreatingEssences();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CreatingEssences()
    {
        GameObject essence;

        for (int i = 0; i < essenceCount; i++)
        {
            essence = Instantiate(essencePrefab, spawnPos, Quaternion.identity);
            essence.SetActive(false);
            Essences.Add(essence);
        }
    }

    public GameObject GetEssences()
    {
        for (int i = 0; i < essenceCount; i++)
        {
            if (!Essences[i].activeInHierarchy)
            {
                Debug.Log(Essences[i].name + " " + i);
                return Essences[i];
            }
        }
        return null;
    }

}
