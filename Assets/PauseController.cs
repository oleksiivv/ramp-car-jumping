using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;

    public ScenesManager scenesManager;

    public Text levelLabelWinPanel, nextLevelLabelWinPanel, levelLabel;

    private AdmobController admob;

    private void Start() {
        Resume();

        levelLabel.text = Application.loadedLevel.ToString();
        levelLabelWinPanel.text = "LEVEL "+Application.loadedLevel.ToString();
        nextLevelLabelWinPanel.text = "NEXT: LEVEL "+(Application.loadedLevel+1).ToString();

        admob = gameObject.AddComponent<AdmobController>();
    }

    public void Pause(){
        Time.timeScale=0;

        pausePanel.SetActive(true);

        admob.showIntersitionalAd();
    }

    public void Resume(){
        Time.timeScale=1;

        pausePanel.SetActive(false);
    }

    public void Restart(){
        Time.timeScale=1;

        admob.showIntersitionalAd();

        scenesManager.OpenScene(Application.loadedLevel);
    }

    public void Next(bool isLast=false){
        Time.timeScale=1;

        admob.showIntersitionalAd();
        if(isLast){
            scenesManager.OpenScene(0);

            return;
        }

        scenesManager.OpenScene(Application.loadedLevel+1);
    }
}
