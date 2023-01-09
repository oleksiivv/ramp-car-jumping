using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCarController : MonoBehaviour
{
    [HideInInspector]
    public CarController car;

    private float force;

    void Update(){
        if(Input.GetMouseButton(0)){
            force++;
            //Debug.Log(force);
        }

        if(Input.GetMouseButtonUp(0)){
            //car.Move(force);
            force=0;
        }
    }
}
