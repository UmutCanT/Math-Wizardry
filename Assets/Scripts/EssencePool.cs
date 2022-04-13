using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssencePool : MonoBehaviour
{
    public static EssencePool SharedInstance;

    private List<GameObject> essences = new List<GameObject>();

    [SerializeField] GameObject essencePrefab;
    readonly int essenceCount = 4;
    readonly float essencePositionY = ScreenSize.instance.Height + 1f;
    public List<GameObject> Essences { get => essences; set => essences = value; }

    void Awake()
    {
        SharedInstance = this;
        CreatingEssences();
    }

    void CreatingEssences()
    {
        GameObject essence;

        for (int i = 0; i < essenceCount; i++)
        {
            essence = Instantiate(essencePrefab, new Vector3(EssencePositionsX(i), essencePositionY, 0), Quaternion.identity);
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
