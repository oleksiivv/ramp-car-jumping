using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBox : MonoBehaviour
{
    public void rate(){
      PlayerPrefs.SetInt("rate_after_finish_panel_showed", 1);
      PlayerPrefs.SetInt("rated", 1);

      Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudioGames.CarParkingFrog");
      
      gameObject.SetActive(false);
    }

    public void remindLater(){
      LevelsController.ShowRateBoxCnt=2;
      gameObject.SetActive(false);
    }

    public void remindNewer(){
      PlayerPrefs.SetInt("rated", 1);
      gameObject.SetActive(false);
    }

    public void doNotRate(){
      PlayerPrefs.SetInt("rate_after_finish_panel_showed", 1);
      PlayerPrefs.SetInt("rated", 1);
      gameObject.SetActive(false);
    }
}
