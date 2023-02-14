using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button6 : MonoBehaviour
{
    [SerializeField] private GameObject _Keypad;

    public void ClickSix()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        _Keypad.GetComponent<MainDoorKeyPad>().Six();
    }
}
