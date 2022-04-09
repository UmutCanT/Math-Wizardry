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
            essence = Instantiate(essencePrefab, new Vector3(EssencePositionsX(i), ScreenSize.instance.Height, 0), Quaternion.identity);
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
                return Essences[i];
            }
        }
        return null;
    }

    float EssencePositionsX(int order)
    {
        return order switch
        {
            0 => ScreenSize.instance.Width / 4,
            1 => -ScreenSize.instance.Width / 4,
            2 => 3 * ScreenSize.instance.Width / 4,
            3 => -3 * ScreenSize.instance.Width / 4,
            _ => throw new System.NotImplementedException()
        };
    }
}
