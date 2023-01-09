using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    public List<AudioClip> clips;

    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        
        audioSource.enabled = PlayerPrefs.GetInt("!music") == 0;

        if(!audioSource.enabled)return;

        audioSource.enabled = false;

        audioSource.clip = clips[Application.loadedLevel % clips.Count];

        audioSource.enabled = true;

        audioSource.Play();
    }
}
