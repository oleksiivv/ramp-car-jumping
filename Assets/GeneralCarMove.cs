using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralCarMove : MonoBehaviour
{
    public CarMove carMove;

    public GameObject handler;

    public Slider sliderMove;

    public bool isDebug = false;

    public AudioController audioController;

    void Update(){
        if(isDebug){
            if(Input.GetKey(KeyCode.Space)){
                carMove.Move();
            }
            if(Input.GetKeyUp(KeyCode.Space)){
                carMove.StopMove();
            }
        }
    }

    public void PedalRunHandler(){
        if(carMove.Move()){
            audioController.PlayEngine();
        }else{
            audioController.StopEngine();
        }
    }

    public void PedalStopHandler(){
        audioController.StopEngine();
        carMove.StopMove();
    }
}
