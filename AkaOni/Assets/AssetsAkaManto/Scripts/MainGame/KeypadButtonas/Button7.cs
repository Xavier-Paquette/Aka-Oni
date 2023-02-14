using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button7 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;

    public void ClickSeven()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Seven();
    }
}
