using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainDoor : MonoBehaviour
{
    private bool _inRange;
    Collider2D _colObject;
    [SerializeField] GameObject DialogBoxBG;
    private bool _isSolved = false;
    private bool unlocked;
    private bool textDisplaying = false;
    SpriteRenderer _sr;
    CapsuleCollider2D _cc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private Text _DialogText;
    [SerializeField] private Text _PromptText;
    [SerializeField] private Sprite newSprite;
    void Start()
    {
        _DialogText.text = "";
        _PromptText.text = "";


        _sr = gameObject.GetComponent<SpriteRenderer>();
        _cc = gameObject.GetComponent<CapsuleCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        _inRange = true;
        _colObject = col;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        _inRange = false;

        _PromptText.text = "";
        if (_colObject.gameObject.tag == "Player") { _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true; }
    }

    void Update()
    {
        if (_inRange)
        {
            if (_colObject.gameObject.tag == "Player")
            {


                if (!unlocked) { _PromptText.text = "Press E to inspect"; }
                if (Input.GetKey(KeyCode.E))
                {
                    _colObject.gameObject.GetComponent<PlayerMovement>().enabled = false;
                    _PromptText.text = "";
                    DialogBoxBG.SetActive(true);
                    if (_isSolved == true)
                    {

                        _DialogText.text = "You unlocked the main exit!";
                        unlocked = true;
                        textDisplaying = true;
                        _sr.sprite = newSprite;
                        _cc.enabled = false;
                        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                    }
                    else
                    {
                        _DialogText.text = "This is the main exit! It's locked shut, I think I have to use this keypad to unlock it...";
                        textDisplaying = true;
                        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                    }


                }
                if (textDisplaying)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        textDisplaying = false;
                        DialogBoxBG.SetActive(false);
                        _DialogText.text = "";
                        _PromptText.text = "";
                        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                    }
                }

            }
        }
        if (textDisplaying)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                textDisplaying = false;
                DialogBoxBG.SetActive(false);
                _DialogText.text = "";


            }
        }


    }
    public void Solve() {
        _isSolved = true;  
    }
}
