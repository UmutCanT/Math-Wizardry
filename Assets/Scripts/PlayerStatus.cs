using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerStatus
{
    public PlayerStatusTypes type;
    public GameObject gameObject;
}
public enum PlayerStatusTypes
{
    AnsweringCorrect,
    AnsweringWrong,
    Healing
}