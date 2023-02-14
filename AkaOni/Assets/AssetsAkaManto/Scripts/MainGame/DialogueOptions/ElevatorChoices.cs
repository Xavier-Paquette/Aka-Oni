using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElevatorChoices : MonoBehaviour
{
    [SerializeField] private GameObject dialogueOptions;
    [SerializeField] private GameObject DialogueBox;
    private Vector3 ChosenPos;
    private Vector3 ElevatorPos;
    private Vector3 Floor3Pos;
    private Vector3 Floor2Pos;
    private Vector3 Floor1Pos;
    private GameObject _player;
    [SerializeField] private GameObject _bgAudio;
    // Start is called before the first frame update
    void Start()
    {
        dialogueOptions.SetActive(false);
        _player = GameObject.Find("Player");
        ElevatorPos = new Vector3(-60.79f,28.3f,1);
        Floor3Pos = new Vector3(-1.79f,2.08f,1);
        Floor2Pos = new Vector3(3.5f,-43.01f,1);
        Floor1Pos = new Vector3(2.22f,-89.71f,1);
    }

    public void Floor3Click() {
        dialogueOptions.SetActive(false);
        DialogueBox.SetActive(false);
        _player.transform.position = ElevatorPos;
        ChosenPos = Floor3Pos;
        StartCoroutine(waitMethod(ChosenPos));
    }
    public void Floor2Click()
    {
        dialogueOptions.SetActive(false);
        DialogueBox.SetActive(false);
        _player.transform.position = ElevatorPos;
        ChosenPos = Floor2Pos;
        StartCoroutine(waitMethod(ChosenPos));
    }
    public void Floor1Click()
    {
        dialogueOptions.SetActive(false);
        DialogueBox.SetActive(false);
        _player.transform.position = ElevatorPos;
        ChosenPos = Floor1Pos;
        StartCoroutine(waitMethod(ChosenPos));
    }

    IEnumerator waitMethod(Vector3 ChosenPos) {
        //screen shake + rumble noise
        _bgAudio.SetActive(false);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        yield return new WaitForSeconds(3);
        //play Ding sound effect
        _bgAudio.SetActive(true);
        _player.transform.position = ChosenPos;
        audio.Stop();

    }
}
