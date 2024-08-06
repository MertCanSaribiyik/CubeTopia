using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource source;
    public List<AudioClips> clips;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }

        else {
            Instance = this;
        }

        source = GetComponent<AudioSource>();
    }

    public void PlayOneShot(string clipName) {
        AudioClip clip = clips.Find(x => x.clipName == clipName).clip;

        if(clip != null) {
            source.PlayOneShot(clip);
        }
    }

    public void PlayOneShot(AudioClip clip) {
        if (clip != null) {
            source.PlayOneShot(clip);
        }
    }
}

[Serializable]
public struct AudioClips
{
    public string clipName;
    public AudioClip clip;
}
