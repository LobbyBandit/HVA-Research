using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class HelpAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;

    public bool isActivated;
    bool hasPlayed;


    // Start is called before the first frame update
    void Start()
    {
        AudioSetup();
    }
    void OnEnable()
    {
        if (hasPlayed)
            return;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            hasPlayed = true;
            isActivated = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
            return;
        else
        {
            hasPlayed = false;
            enabled = false;
        }

    }

    void AudioSetup()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
    }

    public void Deactivate()
    {
        isActivated = false;
    }

}
