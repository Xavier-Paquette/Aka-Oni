using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button8 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;
    public void ClickEight()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Eight();
    }
}
