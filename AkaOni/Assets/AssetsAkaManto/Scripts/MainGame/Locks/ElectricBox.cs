using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElectricBox : MonoBehaviour
{
    private bool _inRange;
    Collider2D _colObject;
    [SerializeField] GameObject DialogBoxBG;
    private bool unlocked;
    SpriteRenderer _sr;
    private bool textDisplaying = false;
    CapsuleCollider2D _cc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private Text _DialogText;
    [SerializeField] private Text _PromptText;
    [SerializeField] private ItemData _Key;
    [SerializeField] private GameObject ElevatorFloor1;
    [SerializeField] private GameObject ElevatorFloor2;
    [SerializeField] private GameObject ElevatorFloor3;
    [SerializeField] private Sprite newSprite;
    Animator _anim;
    void Start()
    {
        _DialogText.text = "";
        _PromptText.text = "";
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _cc = gameObject.GetComponent<CapsuleCollider2D>();
        _anim = gameObject.GetComponent<Animator>();
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
                    if (_colObject.gameObject.GetComponent<Player>().FindItem(_Key))
                    {
                        ElevatorFloor1.GetComponent<ElevatorController>().Fix();
                        ElevatorFloor2.GetComponent<ElevatorController>().Fix();
                        ElevatorFloor3.GetComponent<ElevatorController>().Fix();
                        _DialogText.text = "You used the cables to fix the broken electrical box. The elevator is now working!";
                        _anim.SetBool("isFixed", true);
                        _sr.sprite = newSprite;
                        unlocked = true;
                        textDisplaying = true;
                        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;

                    }
                    else
                    {
                        _DialogText.text = "Something is wrong with this elevator control panel... \n it seems to be missing some cables.";
                        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                        textDisplaying = true;
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
}
