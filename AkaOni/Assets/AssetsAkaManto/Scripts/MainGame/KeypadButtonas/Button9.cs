using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button9 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;
    public void ClickNine()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Nine();
    }
}
