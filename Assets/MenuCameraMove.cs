using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMove : MonoBehaviour
{
    public LevelsController levelsController;

    private bool moveToLastLevel;

    public Vector3 aimPos;

    private GameObject aimObject;

    public GameObject openLevelsBarrier;

    public GameObject firstLevel, lastLevel;

    void Start(){
        var lastLevelIndex = levelsController.GetLastLevel()-1;
        lastLevelIndex = lastLevelIndex > levelsController.levels.Length - 1 ? levelsController.levels.Length - 1 : lastLevelIndex;
        aimObject = levelsController.levels[lastLevelIndex];

        moveToLastLevel=false;
    }

    public void InvokeMovement(float time){
        Invoke(nameof(MoveToLastLevel), time);
    }

    void Update(){
        if(moveToLastLevel){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(aimObject.transform.position.x, aimPos.y, aimPos.z), 0.25f);

            if(transform.position.x == aimObject.transform.position.x)moveToLastLevel=false;
        } 
        if(!openLevelsBarrier.activeSelf){
            if (Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0)) {
                RaycastHit hit;
                //Create a Ray on the tapped / clicked position
                Ray ray;
                //for unity editor
                #if UNITY_EDITOR
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //for touch device
                #elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                #endif
            
                //Check if the ray hits any collider
                if(Physics.Raycast(ray,out hit))
                {
                    var endPoint = hit.point;
                    
                    Debug.Log(endPoint);

                    if(endPoint.x > firstLevel.transform.position.x - 5 && endPoint.x < lastLevel.transform.position.x + 5){
                        StopAllCoroutines();
                        StartCoroutine(ScrollCamera(endPoint.x));
                    }
                    //transform.position = new Vector3(endPoint.x, transform.position.y, transform.position.z);
                }
            }
        }
    }

    IEnumerator ScrollCamera(float xPos){
        while(true){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, transform.position.y, transform.position.z), 0.1f);

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void MoveToLastLevel(){
        openLevelsBarrier.gameObject.SetActive(false);
        moveToLastLevel=true;
    }

    public void StopMoveToLastLevel(){
        moveToLastLevel=false;
    }
}
