using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPanelShow : MonoBehaviour
{
    public GameObject[] components;

    public float delay=2f;

    void Start(){
        if (Time.timeScale == 0){
            show();
            return;
        }

        foreach(var component in components){
            component.SetActive(false);
        }

        Invoke(nameof(show), delay);
    }

    void show(){
        foreach(var component in components){
            component.SetActive(true);
        }
    }
}
