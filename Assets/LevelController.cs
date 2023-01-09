using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelController : MonoBehaviour
{
    public Image handle;

    public Slider handleSlider;

    public bool hasHandle;

    public List<string> carsPattern;

    public List<Sprite> carsPatternIcons;

    public GameObject[] slots;

    public AudioController audioController;

    void Start() {
        if (!hasHandle) {
            handle.transform.localScale = new Vector3(0, 0, 0);
            handleSlider.GetComponent<Slider>().interactable = false;
        } else {
            handle.transform.localScale = new Vector3(1, 1, 1);
            handleSlider.GetComponent<Slider>().interactable = true;
        }

        darkPattern();

        showPattern();
    }

    void showPattern(){
        int i=0;
        
        foreach(var slot in slots){
            slot.SetActive(false);
        }

        foreach(var carPatternItem in carsPattern){
            var sprite = carsPatternIcons.Where(item => item.name.Contains(carPatternItem)).First();

            slots[carsPattern.Count - i - 1].SetActive(true);
            slots[carsPattern.Count - i - 1].GetComponent<Image>().sprite = sprite;

            i++;
        }

        Invoke(nameof(InvokeHighlightPattern), 0.5f);
    }

    void darkPattern(){
        for(int i=0; i<carsPattern.Count; i++){
            slots[i].GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
    }

    void InvokeHighlightPattern(){
        StartCoroutine(HighlightPattern());
    }

    IEnumerator HighlightPattern(){
        for(int i=0; i<carsPattern.Count; i++){
            slots[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            audioController.PlayBell(i);
            yield return new WaitForSeconds(0.7f);
        }
    }
}
