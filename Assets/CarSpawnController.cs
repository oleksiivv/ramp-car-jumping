using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    public List<CarController> cars;

    public Vector3 spawnPosition;

    public RunCarController runCarController;

    public GridRow gridRow;

    public GeneralCarMove generalCarMove;

    [HideInInspector]
    public int currentCartId = 0;

    void Start(){
        CarController.platformIsFree = true;
        currentCartId=0;
        Spawn();
    }

    void Update(){
        //Debug.Log("Platform is active: "+CarController.platformIsFree.ToString());
        //checkGameState();
    }

    public void Spawn(){
        currentCartId++;
        
        if(!CarController.platformIsFree)return;

        if(currentCartId>=cars.Count)return;

        CarController.platformIsFree = false;

        CarController car = cars[currentCartId];

        Debug.Log(currentCartId);

        var newCar = Instantiate(car.gameObject, spawnPosition, car.gameObject.transform.rotation) as GameObject;

        runCarController.car = newCar.GetComponent<CarController>();
        newCar.GetComponent<CarController>().carSpawnController = this;

        generalCarMove.carMove = newCar.GetComponent<CarMove>();

        generalCarMove.carMove.Init(generalCarMove.sliderMove, generalCarMove.handler);

        //gridRow.addAimObject(car.gameObject);
    }

    public void InvokeCheckGameState(){
        Invoke(nameof(checkGameState), 6f);
    }

    void checkGameState(){
        gridRow.check();
        return;
    }

    public void CancelCheckGameState(){
        if(IsInvoking(nameof(checkGameState)))CancelInvoke(nameof(checkGameState));
    }
}
