using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public GameObject playerObject;
    public GameObject levelControl;
    public int currentLane = 1;
    public float startY;
    public float moveSpeed = 10;
    public float leftRightSpeed = 10;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public bool isSliding = false;
    public bool isChangingLane = false;
    public int leftRight;
    public float[] lanePositions = {-4f, 0f, 4f};

    void Start() {
        startY = transform.position.y;
    }

    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove && !isChangingLane) {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && currentLane > 0) {
                currentLane = currentLane - 1;
                leftRight = -1;
                isChangingLane = true;
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && currentLane < 2) {
                currentLane = currentLane + 1;
                leftRight = 1;
                isChangingLane = true;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
                if (!isJumping && !isSliding){
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                if (!isJumping && !isSliding){
                    isSliding = true;
                    playerObject.GetComponent<Animator>().Play("Sprinting Forward Roll");
                    StartCoroutine(SlideSequence());
                }
            }
        }
        if (isJumping) {
            if (comingDown) {
                transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
            } else {
                transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
            }
        }
        if (isChangingLane) {
            if (leftRight == -1){
                if (transform.position.x > lanePositions[currentLane]) {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                } else {
                    isChangingLane = false;
                }
            } else {
                if (transform.position.x < lanePositions[currentLane]) {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                } else {
                    isChangingLane = false;
                }
            }
       }
    }

    IEnumerator JumpSequence() {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        comingDown = false;
        isJumping = false;
        transform.position = new Vector3(transform.position.x, startY , transform.position.z);
        if (!levelControl.GetComponent<EndRunSequence>().enabled) {
            playerObject.GetComponent<Animator>().Play("Running");
        }
    }

    IEnumerator SlideSequence() {
        yield return new WaitForSeconds(1.05f);
        isSliding = false;
        if (!levelControl.GetComponent<EndRunSequence>().enabled) {
            playerObject.GetComponent<Animator>().Play("Running");
        }
    }
}
