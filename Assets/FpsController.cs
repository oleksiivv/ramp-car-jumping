using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public Text fpsCount;

    public bool isDebug=false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 40;

        if(!isDebug){
            fpsCount.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDebug)fpsCount.GetComponent<Text>().text = "FPS: " + ((int)(1f / Time.unscaledDeltaTime)).ToString() ;
    }
}
