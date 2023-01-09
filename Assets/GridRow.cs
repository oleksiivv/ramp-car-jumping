using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridRow : MonoBehaviour
{
    public LevelController level;

    public List<GameObject> cars;

    public WinUIController winUiController;

    public LoseUIController loseUIController;

    public AudioController audioController;

    private bool eventHasHappen=false;

    void Start(){
        cars = new List<GameObject>();

        eventHasHappen=false;

        //DEBUG ONLY
        //WinBehaviour();
    }
    
    public void addAimObject(GameObject car){
        if(!cars.Contains(car))
        {
            cars.Add(car);
        }

        Invoke(nameof(check), 1f);
    }

    public void check(){

        if(cars.Count != level.carsPattern.Count)return;
        
        var isSuccessful = true;

        cars.Sort(
            delegate(GameObject o1, GameObject o2)
            {
                return o2.transform.position.x.CompareTo(o1.transform.position.x);
            }
        );

        int i;
        for(i=0; i<level.carsPattern.Count; i++){
            //Debug.Log(level.carsPattern[i]);
            if(i<cars.Count){
                Debug.Log(level.carsPattern[i].ToString() + " - " + cars[i].name.ToString());
                Debug.Log(i.ToString() + " / " + (level.carsPattern.Count-1).ToString());

                if(! cars[i].name.ToString().Contains(level.carsPattern[i].ToString())){
                    isSuccessful=false;
                }
            }
        }

        if(!isSuccessful){
            isSuccessful=true;
            for(i=0; i<level.carsPattern.Count; i++){
                if(i<cars.Count){
                    if(! cars[cars.Count() - 1 - i].name.ToString().Contains(level.carsPattern[i].ToString())){
                        isSuccessful=false;
                    }
                }
            }
        }

        //Debug.Log(isSuccessful.ToString() + " / " + (cars.Count == level.carsPattern.Count).ToString());

        if(!isSuccessful){
            LoseBehaviour();

            return;
        }
        
        isSuccessful = isSuccessful && (cars.Count == level.carsPattern.Count);

        if(isSuccessful){
            WinBehaviour();

            return;
        }

        Invoke(nameof(check), 1f);
    }

    public void LoseBehaviour(){
        if(eventHasHappen)return;

        eventHasHappen=true;

        audioController.PlayLose();
        loseUIController.LoseBehaviour();
    }

    public void WinBehaviour(){
        if(eventHasHappen)return;

        eventHasHappen=true;

        PlayerPrefs.SetInt("level#"+Application.loadedLevel.ToString(), 1);

        audioController.PlayWin();
        winUiController.WinBehaviour();
    }
}
