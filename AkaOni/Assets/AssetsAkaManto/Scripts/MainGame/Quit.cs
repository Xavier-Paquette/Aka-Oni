using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField] GameObject QuitGameCanvas;
    public void ReturnMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGameCanvas.SetActive(true);
        }
    }
}

