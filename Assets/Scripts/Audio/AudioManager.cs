using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public bool playingMenuMusic = true;
    public bool playingSong1 = false;
    public bool playingSong2 = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayMenuMusic(string name)  //0.4f
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }

        else if (musicSource.clip.name == "FAZENDA 1" || musicSource.clip.name == "FAZENDA 2")
        {
            musicSource.Stop();
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }
    }

    public void PlayMusic1(string name) //0.3f
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }

        else if (musicSource.clip.name == "MENU E LOJA" || musicSource.clip.name == "FAZENDA 2")
        {
            musicSource.Stop();
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }
    }

    public void PlayMusic2(string name) //0.7f
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }

        else if (musicSource.clip.name == "MENU E LOJA" || musicSource.clip.name == "FAZENDA 1")
        {
            musicSource.Stop();
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = s.clip;
            musicSource.PlayOneShot(s.clip);
            musicSource.PlayScheduled(AudioSettings.dspTime + s.clip.length);
        }
    }

    public void PlaySFX(string name, float volume)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip, volume);
        }
    }

    public void PlaySFX2(string name, float volume1, float volume2)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }

        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip, Random.Range(volume1, volume2));
        }
    }

    public void MusicVolume (float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

