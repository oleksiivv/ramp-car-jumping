using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelController : MonoBehaviour
{
    public int level;

    public ScenesManager scenesManager;

    public GameObject openLevelBarrier;

    private void OnMouseUp() {
        if(openLevelBarrier.activeSelf)return;
        if(level==1 || PlayerPrefs.GetInt("level#"+(level-1).ToString(), 0)==1){
            scenesManager.OpenSceneAsync(level);
            //Application.LoadLevel(level);
        }
    }
}
