using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public static int ShowRateBoxCnt = 0;

    public GameObject[] levels;

    public GameObject[] padlocks;

    public GameObject gameIsCompletedPanel, ratePanel;

    void Awake(){
        foreach(var padlock in padlocks)padlock.SetActive(true);

        if(ShowRateBoxCnt%2 == 1){
            if(PlayerPrefs.GetInt("rated", 0) == 0){
                ratePanel.SetActive(true);
            }
        }
        ShowRateBoxCnt++;
    }

    public int GetLastLevel(){
        int i=1;
        for(i=1; i<=levels.Length; i++){
            padlocks[i-1].SetActive(false);
            if(PlayerPrefs.GetInt("level#"+i.ToString(), 0)!=1){
                break;
            }
        }

        if(gameIsCompletedPanel != null){
            if(i>=levels.Length && PlayerPrefs.GetInt("rate_after_finish_panel_showed", 0) == 0){
                gameIsCompletedPanel.SetActive(true);

                PlayerPrefs.SetInt("rate_after_finish_panel_showed", 1);
            }
        }

        return i;
    }
}
