using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour {
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;
    public static int distanceRun;
    public bool addingDistance = false;
    public float disDelay = 0.5f;

    void Update() {
        if (addingDistance == false){
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }        
    }

    IEnumerator AddingDistance() {
        distanceRun += 1;
        distanceDisplay.GetComponent<Text>().text = "" + distanceRun;
        distanceEndDisplay.GetComponent<Text>().text = "" + distanceRun;
        yield return new WaitForSeconds(disDelay);
        addingDistance = false;
    }
}
