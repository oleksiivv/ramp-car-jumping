using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public Slider moveSlider;

    private float acceleration;

    public GameObject handler;

    private bool isMoving=false;

    private Rigidbody rigidbody;

    private CarController carController;

    public void Init(Slider _moveSlider, GameObject _handler){
        this.handler = _handler;
        this.moveSlider = _moveSlider;

        moveSlider.value = 0;
        transform.eulerAngles=new Vector3(0,-90+moveSlider.value*20,0);
        handler.transform.eulerAngles=new Vector3(0,0,moveSlider.value*-1*60);
    }

    void Awake()
     {
         Input.multiTouchEnabled = true;
     }

    void Start(){
        acceleration=0;

        rigidbody = GetComponent<Rigidbody>();
        carController = GetComponent<CarController>();
    }

    void Update(){
        if(!moveSlider)return;
    
        if(isMoving){
            if(acceleration<2)acceleration+=0.125f;
            else acceleration+=0.045f;

            //Debug.Log(acceleration);

            //gameObject.transform.position-=new Vector3(acceleration,0,0)*acceleration;
            rigidbody.AddRelativeForce(Vector3.forward*acceleration, ForceMode.Impulse);

            if(Mathf.Abs(transform.eulerAngles.y!-(-90+moveSlider.value*35))>0.1f){
                transform.eulerAngles+=new Vector3(0, moveSlider.value*acceleration/5,0);
            }
            //handler.transform.eulerAngles=new Vector3(0,0,moveSlider.value*-1*35);
        }

        handler.transform.eulerAngles=new Vector3(0,0,moveSlider.value*-1*35);
    }

    public bool Move(){
        if(carController.canMove){
            isMoving=true;
            carController.runFX.Play();
        }else{
            isMoving=false;
            carController.runFX.Stop();
        }

        return carController.canMove;
    }

    public void StopMove(){
        isMoving=false;

        carController.runFX.Stop();
    }
}
