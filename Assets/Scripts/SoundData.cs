using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundData
{
    public String name;
    public AudioClip[] Clips;
    
    public AudioClip GetRandomCLip()
    {
        int rnd = UnityEngine.Random.Range(0, Clips.Length);
        return Clips[rnd];
    }
}
