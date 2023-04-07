using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour {
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject levelControl;

    void OnTriggerEnter(Collider other) {
        if (this.gameObject.tag == "Slide" && thePlayer.GetComponent<PlayerMove>().isSliding) {
            return;
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}