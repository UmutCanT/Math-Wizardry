using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public struct Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}

public enum SoundType
{
    MenuChange,
    OnCorrect,
    OnWrong,
    BackButton,
    DiffChangeButton,
    PlayButton,
    Heal
}
