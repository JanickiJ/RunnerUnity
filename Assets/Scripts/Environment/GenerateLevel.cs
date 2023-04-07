using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel: MonoBehaviour {
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public float startX;
    public float startY;
    public float startZ;

    void Start() {
        GameObject startGameObject = GameObject.Find("SectionStart");
        startX = startGameObject.transform.position.x;
        startY = startGameObject.transform.position.y;
        startZ = startGameObject.transform.position.z;
        StartCoroutine(GenerateSection(0));
    }

    void Update() {
        if (creatingSection == false) {
            creatingSection = true;
            StartCoroutine(GenerateSection(10));
        }        
    }

    IEnumerator GenerateSection(float waitingTime) {
         secNum = Random.Range(0,3);
         Instantiate(section[secNum], new Vector3(startX, startY, startZ + zPos), Quaternion.identity);
         zPos += 50;
         yield return new WaitForSeconds(waitingTime);
         creatingSection = false;
    }
}
