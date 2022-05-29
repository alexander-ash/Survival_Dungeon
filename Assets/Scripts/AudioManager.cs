using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundController[] sounds;
    public static AudioManager currentInstance;   

    void Awake()
    {

        foreach (SoundController sc in sounds)
        {
            sc.source = gameObject.AddComponent<AudioSource>();
            sc.source.clip = sc.clip;

            sc.source.volume = sc.volume;
            sc.source.pitch = sc.pitch;
            sc.source.loop = sc.loop;
        }
              
    }
    private void Start()
    {
        //PlaySound("Music");        
    }
    public void PlaySound(string name)
    {
        SoundController sc = Array.Find(sounds, soundController => soundController.name == name);
        if (sc == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }
        sc.source.Play();
    }

    public void PlayAndStopSound(string name, bool trigger)
    {
        SoundController sc = Array.Find(sounds, soundController => soundController.name == name);
        if (sc == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }
        if (trigger)
        {
            sc.source.Play();
        }
        else
        {
            sc.source.Stop();
        }
        
    }


    //public void StopSound(string name)
    //{
    //    SoundController sc = Array.Find(sounds, soundController => soundController.name == name);
    //    if (sc == null)
    //    {
    //        Debug.LogWarning($"Cannot Spot audio clip. Sound {name} not found");
    //        return;
    //    }
    //    sc.source.Stop();
    //}


}
