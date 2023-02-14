using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;
    public void ClickOne() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().One();
    }
}
