using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject buttonMutedMusic, buttonNormalMusic;

    public GameObject buttonMutedSound, buttonNormalSound;

    public GameObject audioController;

    public Dropdown quality;
    void Start()
    {
        if(PlayerPrefs.GetInt("quality", -1) == -1){
            PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        }

        quality.GetComponent<Dropdown>().value=PlayerPrefs.GetInt("quality");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));

        if(PlayerPrefs.GetInt("!sound")==0){

            buttonMutedSound.SetActive(false);
            buttonNormalSound.SetActive(true);

        }
        else{
            buttonMutedSound.SetActive(true);
            buttonNormalSound.SetActive(false);
        }

        
        if(PlayerPrefs.GetInt("!music")==0){

            buttonMutedMusic.SetActive(false);
            buttonNormalMusic.SetActive(true);

        }
        else{
            buttonMutedMusic.SetActive(true);
            buttonNormalMusic.SetActive(false);
        }
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        buttonMutedSound.SetActive(true);
        buttonNormalSound.SetActive(false);
        //GetComponent<AudioSource>().enabled=false;
        
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        buttonMutedSound.SetActive(false);
        buttonNormalSound.SetActive(true);

        //GetComponent<AudioSource>().enabled=true;
    }


    public void muteMusic(){
        PlayerPrefs.SetInt("!music",1);
        buttonMutedMusic.SetActive(true);
        buttonNormalMusic.SetActive(false);
        audioController.GetComponent<AudioSource>().enabled=false;
        
    }

    public void unmuteMusic(){
        //GetComponent<AudioSource>().enabled=true;
        //GetComponent<AudioSource>().Play();

        PlayerPrefs.SetInt("!music",0);
        buttonMutedMusic.SetActive(false);
        buttonNormalMusic.SetActive(true);

        audioController.GetComponent<AudioSource>().enabled=true;
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality",qualityIndex);
    }


    void Update(){
        Debug.Log("Quality: " +QualitySettings.GetQualityLevel());
    }



    public GameObject undoProgressPanel;

    public void showUndoProgressPanel(){
        undoProgressPanel.SetActive(true);
    }


    public void undoProgress(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("studied",1);
        PlayerPrefs.SetInt("storyShowed",1);
        undoProgressPanel.SetActive(false);
        Start();
    }

    public void cancelUndoProgress(){
        undoProgressPanel.SetActive(false);
    }


}
