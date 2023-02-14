using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BackgroundManager : MonoBehaviour
{
    private SpriteRenderer _sr;
    [SerializeField] Sprite StartSprite;
    [SerializeField] Sprite BathroomSprite;
    [SerializeField] Sprite BlackSprite;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = StartSprite;
    }

    public void EnterBathroom() { 
        _sr.sprite = BathroomSprite;
    }

    public void DoRitual() {
        _sr.sprite = BlackSprite;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

    }
}
