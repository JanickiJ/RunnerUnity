using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel: MonoBehaviour
{

    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public GameObject startGameObject;

    void Start(){
        startGameObject = GameObject.Find("SectionStart");
        GenerateSection(0);
        GenerateSection(0);
        GenerateSection(0);
    }

    void Update()
    {
        if (creatingSection == false){
            creatingSection = true;
            StartCoroutine(GenerateSection(15));
        }        
    }

    IEnumerator GenerateSection(float waitingTime){
         secNum = Random.Range(0,1);
         Instantiate(section[secNum], new Vector3(startGameObject.transform.position.x,
                                                    startGameObject.transform.position.y,
                                                    startGameObject.transform.position.z + zPos), Quaternion.identity);
         zPos += 50;
         yield return new WaitForSeconds(waitingTime);
         creatingSection= false;
    }
}
