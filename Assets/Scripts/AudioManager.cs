using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    public static AudioManager Instance { get; private set; }
    AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType soundType)
    {              
        audioSource.PlayOneShot(GetAudioClip(soundType));
    }

    public void PlaySound(SoundType soundType, float volume)
    {
        audioSource.PlayOneShot(GetAudioClip(soundType), volume);
    }

    AudioClip GetAudioClip(SoundType soundType)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.soundType == soundType)
            {
                return sound.audioClip;
            }
        }
        Debug.LogError("Sound " + soundType + "not Found");
        return null;
    }
}