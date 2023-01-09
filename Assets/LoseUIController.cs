using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUIController : MonoBehaviour
{
    public GameObject losePanel;

    public void LoseBehaviour(){
        losePanel.SetActive(true);
    }
}
