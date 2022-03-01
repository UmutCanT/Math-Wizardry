using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use with this IObjectPool when Unity version upgraded 
public class EssencePool : MonoBehaviour
{
    List<GameObject> essences = new List<GameObject>();

    [SerializeField] GameObject essencePrefab;
    int essenceCount = 4;
    //For test
    Vector3 spawnPos = new Vector3(0, 5, 0);

    // Start is called before the first frame update
    void Start()
    {
        CreatingEssences();
    }

    void CreatingEssences()
    {
        GameObject essence;

        for (int i = 0; i < essenceCount; i++)
        {
            essence = Instantiate(essencePrefab, spawnPos, Quaternion.identity);
            essence.SetActive(false);
            essences.Add(essence);
        }
    }

    public GameObject GetEssences()
    {
        for (int i = 0; i < essenceCount; i++)
        {
            if (!essences[i].activeInHierarchy)
            {
                return essences[i];
            }
        }
        return null;
    }

}
