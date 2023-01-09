using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public List<AudioClip> bellClips;

    public List<AudioClip> carSmashClips;

    public AudioClip engineClip;

    public AudioClip winEffect, loseEffect;

    private bool startedGame=false;

    public void PlayBell(int n){
        if(PlayerPrefs.GetInt("!sound")==1)return;
        if(startedGame)return;
        audioSource.enabled = false;
        audioSource.clip = bellClips[n % (bellClips.Count)];
        audioSource.enabled = true;

        audioSource.Play();
    }

    public void PlayGameSmash(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        int n = Random.Range(0, carSmashClips.Count);

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = carSmashClips[n];
        audioSource.enabled = true;

        audioSource.Play();
    }

    public void PlayWin(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = winEffect;
        audioSource.enabled = true;

        audioSource.Play();
    }

    public void PlayLose(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = loseEffect;
        audioSource.enabled = true;

        audioSource.Play();
    }

    public void PlayEngine(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        startedGame = true;

        StopAllCoroutines();
        audioSource.enabled = false;
        audioSource.clip = engineClip;
        audioSource.enabled = true;

        audioSource.Play();

        StartCoroutine(MakeEngineLoud());
    }

    public void StopEngine(){
        if(PlayerPrefs.GetInt("!sound")==1)return;
        
        StopAllCoroutines();
        StartCoroutine(MakeEngineQuiet());
    }

    IEnumerator MakeEngineQuiet(){
        while(audioSource.volume>0){
            audioSource.volume -= 0.05f;
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator MakeEngineLoud(){
        while(audioSource.volume<0.5f){
            audioSource.volume += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
