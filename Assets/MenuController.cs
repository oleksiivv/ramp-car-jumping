using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public GameObject moreButtonsPanel;

    public GameObject levelsUIPanel;

    private Vector3 mainMenuPanelStartPosition, moreButtonsPanelStartPosition;

    public MenuCameraMove cameraMove;

    public GameObject openLevelsBarrier;

    bool coroutineIsRunning=false;

    void Start(){
        Time.timeScale = 1;
        
        coroutineIsRunning=false;
        openLevelsBarrier.gameObject.SetActive(true);

        mainMenuPanelStartPosition = mainMenuPanel.transform.position;
        moreButtonsPanelStartPosition = moreButtonsPanel.transform.position;

        HideMoreButtonsPanel();
    }

    public void ShowOrHideMoreButtonsPanel(){
        if(moreButtonsPanel.activeSelf){
            HideMoreButtonsPanel();
            return;
        }

        ShowMoreButtonsPanel();
    }

    private void HideMoreButtonsPanel(){
        StartCoroutine(MovePanelTowardsY(moreButtonsPanel, moreButtonsPanel.transform.position.y + 300, 1));
    }

    private void ShowMoreButtonsPanel(){
        moreButtonsPanel.SetActive(true);
        StartCoroutine(MovePanelTowardsY(moreButtonsPanel, moreButtonsPanelStartPosition.y, -1, true));
    }

    public void HideMainMenu(){
        StartCoroutine(MovePanelTowardsY(mainMenuPanel, mainMenuPanelStartPosition.y-950, -2));

        //todo: call on coroutine completed
        cameraMove.InvokeMovement(1.3f);
    }

    public void ShowMainMenu(){
        openLevelsBarrier.gameObject.SetActive(true);

        mainMenuPanel.SetActive(true);
        StartCoroutine(MovePanelTowardsY(mainMenuPanel, mainMenuPanelStartPosition.y, 2, true));
    }

    IEnumerator MovePanelTowardsY(GameObject panel, float y, int dy, bool activeAtTheEnd=false){
        if(!coroutineIsRunning){
            coroutineIsRunning=true;
            while(Mathf.Abs(Mathf.Abs(panel.transform.position.y)-Mathf.Abs(y))>0.01f){
                //panel.transform.position += new Vector3(0,2f,0)*dy;

                panel.transform.position = Vector3.MoveTowards(panel.transform.position, new Vector3(panel.transform.position.x, y, panel.transform.position.z), 15f);

                yield return new WaitForSeconds(0.001f);
            }

            panel.SetActive(activeAtTheEnd);
            coroutineIsRunning=false;
        }
    }
}
