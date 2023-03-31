using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;

    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(0.5f);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(0.5f);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(0.5f);
        countDownGo.SetActive(true);
        goFX.Play();
        PlayerMove.canMove = true;
    }

}