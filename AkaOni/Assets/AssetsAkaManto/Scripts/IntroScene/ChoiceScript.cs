using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class ChoiceScript : MonoBehaviour
{
    [SerializeField] private GameObject GameCamera;
    public void BlueClick()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        Player.PlayerChoice = "Blue";
        StartCoroutine(waitMethod());
    }

    public void RedClick()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        Player.PlayerChoice = "Red";
        StartCoroutine(waitMethod());
    }

    IEnumerator waitMethod() {
        Vector3 curPos = GameCamera.transform.position;
        for (int i = 0; i < 5; i++)
        {
            GameCamera.transform.position = new Vector3(curPos.x, curPos.y + 0.022f, curPos.z);
            yield return new WaitForSeconds(0.2f);
            GameCamera.transform.position = new Vector3(curPos.x, curPos.y - 0.04f, curPos.z);
            yield return new WaitForSeconds(0.2f);
            GameCamera.transform.position = new Vector3(curPos.x, curPos.y + 0.02f, curPos.z);
        }
        SceneManager.LoadScene("GameScene1");
    }
}
