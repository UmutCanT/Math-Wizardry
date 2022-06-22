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
    SkillCast,
    UltimateCast,
    OnCorrect,
    OnWrong,
    NegativeButton,
    PositiveButton,
    PlayButton
}
