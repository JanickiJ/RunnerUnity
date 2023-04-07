using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour {
    public GameObject fadeIn;

    void Start() {
        StartCoroutine(StartSequence());
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    IEnumerator StartSequence() {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
    }
}
