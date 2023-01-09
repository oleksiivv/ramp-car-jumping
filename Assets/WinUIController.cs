using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUIController : MonoBehaviour
{
    public GameObject winPanel;

    public void WinBehaviour(){
        winPanel.gameObject.SetActive(true);
    }
}
