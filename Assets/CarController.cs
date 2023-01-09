using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [HideInInspector]
    public CarSpawnController carSpawnController;

    private Rigidbody rigidbody;

    [HideInInspector]
    public bool canMove=false;

    public static bool platformIsFree=true;

    public ParticleSystem runFX;

    void Start(){
        rigidbody = gameObject.GetComponent<Rigidbody>();

        canMove=false;
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "platform"){
            canMove=true;
        }
        else{
            carSpawnController.generalCarMove.audioController.PlayGameSmash();
            platformIsFree=true;
            carSpawnController.InvokeCheckGameState();
            carSpawnController.Spawn();
            carSpawnController.gridRow.addAimObject(this.gameObject);
            Destroy(this);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "platform"){
            canMove=false;
            carSpawnController.generalCarMove.PedalStopHandler();
            runFX.Stop();
            Destroy(gameObject.GetComponent<CarMove>());
        }
    }

    public void Move(float force){
        if(canMove){
            rigidbody.velocity = Vector3.left*force;
        }
    }
}
