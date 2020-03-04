using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Awake called before Start
    void Awake()
    {
        // each loop add an audio source
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.pitch = s.pitch;
            s.source.volume = s.volume;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Loop");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound : "+ name +" not found!");
            return;
        }
        s.source.Play();

    }
}
