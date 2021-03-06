using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    [Range(0.1f, 3)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
