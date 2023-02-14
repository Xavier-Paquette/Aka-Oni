using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class MainMenuController : MonoBehaviour
{
    public void Play() {
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        SceneManager.LoadScene("IntroScene");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

    }
    public void Quit() {
        Application.Quit();
    }
}
