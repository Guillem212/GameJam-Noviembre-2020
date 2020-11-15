using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{    
    public Sound[] sounds;

    public AudioMixerGroup audioMixerMaster;

    //public static AudioManager instance;         

    // Use this for initialization
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixerMaster; //to control volume            
        }
    }    

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }        

    public void f_HitOnOtherHookDirectly()
    {
        Play("hookImpact");
    }

    public void f_CutPlayerHook()
    {
        Play("hookCut");
    }

    public void f_HitOnOtherPlayer()
    {
        Play("hookImpact");
        Play("itemPickup");
    }

    public void f_HookShoot()
    {
        StartCoroutine(ShootHook());
    }

    public void f_HookShootLimitReached()
    {
        Stop("hookLoop");
        Play("hookRetracting");
    }

    public void f_PickUpHook()
    {
        Play("hookPickup");
    }

    IEnumerator ShootHook()
    {
        Play("hookShoot");
        yield return new WaitForSeconds(0.2f);
        Play("hookLoop");
    }
    

    /// <summary>
    /// Applies to a sound a certain volume in a smooth way due to a lerp factor amount
    /// </summary>
    /// <param name="soundName"></param>
    /// <param name="soundVolume"></param>
    public void SetVolumeSmooth(string soundName, float soundVolume, float lerpAmount)
    {
        StartCoroutine(SmoothSound(soundName, soundVolume, lerpAmount));
    }
    
    private IEnumerator SmoothSound(string soundName, float desiredVolume, float lerpFactor) 
    {
        float lerpAmount = 0f;
        Sound desiredSound = Array.Find(sounds, sound => sound.name == soundName);
        float initialVolume = desiredSound.source.volume;//stores background music volume              
        while (lerpAmount < 1f)
        {
            desiredSound.source.volume = Mathf.Lerp(initialVolume, desiredVolume, lerpAmount);
            lerpAmount += lerpFactor * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }


    /// <summary>
    /// Reproduces a sound each "Random" time
    /// </summary>
    /// <returns></returns>
    private IEnumerator RandomNoises()
    {        
        yield return new WaitForSeconds(UnityEngine.Random.Range(25f, 45f));
        //if (UnityEngine.Random.Range(0f, 1f) > 0.5f) PlaySoundWithRandomPitch(0); //wood sound                        
        yield return null;        
    }         
}
