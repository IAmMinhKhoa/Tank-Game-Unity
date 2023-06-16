using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BackGround,
    Shoot,
    Explosion,
    PickUp,
    Error,
    TankTrack,
    Swamp,
    Spam_Tank,
    Click,
    BackGround_GameOver
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public float originalVolume; // L?u tr? gi� tr? �m l??ng ban ??u c?a �m thanh

    public void SetOriginalVolume(float value)
    {
        originalVolume = value;
    }
}

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;

    public List<Sound> sounds;

    private Dictionary<SoundType, AudioSource> audioSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        audioSources = new Dictionary<SoundType, AudioSource>();

        foreach (Sound sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            sound.SetOriginalVolume(sound   .volume); // L?u tr? gi� tr? �m l??ng ban ??u c?a �m thanh
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;

            audioSources.Add((SoundType)System.Enum.Parse(typeof(SoundType), sound.name), source);
        }
       
    }
    void Start()
    {
         Sound_Manager.instance.PlaySound(SoundType.BackGround);
    }

    public void PlaySound(SoundType soundType)
    {
        if (audioSources.ContainsKey(soundType))
        {
            audioSources[soundType].Play();
        }
    }

    public void StopSound(SoundType soundType)
    {
        if (audioSources.ContainsKey(soundType))
        {
            audioSources[soundType].Stop();
        }
    }
    public void PauseSound()
    {
        foreach (KeyValuePair<SoundType, AudioSource> entry in audioSources)
        {
            entry.Value.volume = 0f;
        }
       
    }
    public void SetAllVolumesToOriginal()
    {
        foreach (KeyValuePair<SoundType, AudioSource> entry in audioSources)
        {
            Sound sound = sounds.Find(s => s.name == entry.Key.ToString());
            entry.Value.volume = sound.originalVolume;
        }
    }

}
