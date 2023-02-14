using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClear : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;
    public void ClickClear()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Clear();
    }
}
