using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button5 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;

    public void ClickFive()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Five();
    }
}
