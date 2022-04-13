using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public static ScreenSize instance = null;

    float height;
    float width;

    public float Height { get => height;}
    public float Width { get => width;}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }else if(instance != this){
            Destroy(gameObject);
        }

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }
}
