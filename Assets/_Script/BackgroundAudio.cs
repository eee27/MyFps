using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource lowBloodAudio;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        if (GlobalData.blood <= 30)
        {
            audioSource.volume = 0;
            lowBloodAudio.volume = 0.8f;
        }
        else
        {
            audioSource.volume = 0.8f;
            lowBloodAudio.volume = 0;
        }
    }
}