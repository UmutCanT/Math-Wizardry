using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetMusicVolume(float vol)
    {
        audioMixer.SetFloat("MasterVolume", vol);
    }
}
