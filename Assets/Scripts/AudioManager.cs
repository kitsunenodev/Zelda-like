using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public SoundData[] Clips;

    public float VolumeMusic = 1; 
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        PlayMusic("battleThemeA");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip getClip(String name)
    {
        foreach (var item in Clips)
        {
            foreach (var music in item.Clips)
            {
                if (item.name == name)
                {
                    return music;
                }
            }
            
        }
        return null;
    }

    public void PlayMusic(String name)
    {
        AudioClip clip = getClip(name);
        if (clip != null)
        {
            GameObject go = new GameObject();
            go.name = name;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = VolumeMusic;
            source.loop = true;
            source.Play();
        }
    }

    public void PlaySound(String name)
    {
        AudioClip clip = getClip(name);
        if (clip != null)
        {
            GameObject go = new GameObject();
            go.name = name;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = VolumeMusic;
            source.Play();
            GameObject.Destroy(go, source.clip.length);
        }
    }
    

   
}
