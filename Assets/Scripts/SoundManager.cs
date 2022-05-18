using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sounds[] sounds;

    private void Awake()
    {

        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(instance);
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
       Sounds s= Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            Debug.LogWarning(string.Format("Sound {0} not found", s.name));
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning(string.Format("Sound {0} not found", s.name));
        }
        s.source.Stop();
    }

    public void ChangeVolume(string name, float volume)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning(string.Format("Sound {0} not found", s.name));
        }
        s.source.volume = volume;
    }
}
