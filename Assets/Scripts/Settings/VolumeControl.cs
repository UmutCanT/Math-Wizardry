using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider slider;
    [SerializeField] float multiplier = 30f;
    [SerializeField] Toggle toggle;
    bool disableToggleEvent;
    readonly float defaultValue = 0.75f;

    void Awake()
    {
        slider.onValueChanged.AddListener(SliderValueHandler);
        toggle.onValueChanged.AddListener(ToggleValueHandler);
    }

    void ToggleValueHandler(bool enableSound)
    {
        if (disableToggleEvent)
            return;

        
        if (enableSound)
        {
            if (PlayerPrefs.HasKey(volumeParameter))
            {
                slider.value = PlayerPrefs.GetFloat(volumeParameter);
            }
            else
                slider.value = defaultValue;
            
        }
        else
            slider.value = slider.minValue;
    }   

    void OnEnable()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, defaultValue);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    private void SliderValueHandler(float value)
    {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(value) *  multiplier);
        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
    }
}
