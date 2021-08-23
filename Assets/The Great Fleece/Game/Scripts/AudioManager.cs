using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The Audio Manager is NULL!");
            }
            return _instance;
        }
    }

    public AudioSource VoiceOver;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip cliptoplay)
    {
        VoiceOver.clip = cliptoplay;
        VoiceOver.Play();
    }

}
