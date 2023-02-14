using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElevatorController : MonoBehaviour
{
    private bool _isFixed = false;
    private bool _inRange;
    Collider2D _colObject;
    [SerializeField] GameObject DialogBoxBG;
    private bool unlocked;
    private bool textDisplaying = false;
    [SerializeField] GameObject DialogBoxChoicesBG;

    CapsuleCollider2D _cc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private Text _DialogText;
    [SerializeField] private Text _PromptText;
    void Start()
    {
        _DialogText.text = "";
        _PromptText.text = "";
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
                    if (_isFixed == true)
                    {
                        _DialogText.text = "Please select a floor: ";
                        DialogBoxChoicesBG.SetActive(true);

                        unlocked = true;
                        textDisplaying = true;
                    }
                    else
                    {
                        _DialogText.text = "This elevator is broken...";
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

    public void Fix() { 
        _isFixed = true;
    }


}
