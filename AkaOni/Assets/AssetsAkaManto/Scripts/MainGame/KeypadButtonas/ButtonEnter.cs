using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnter : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;
    public void ClickEnter()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Enter();
    }
}
