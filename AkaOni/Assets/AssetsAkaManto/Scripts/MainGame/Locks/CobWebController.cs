using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CobWebController : MonoBehaviour
{
    private bool _inRange;
    Collider2D _colObject;
    [SerializeField] GameObject DialogBoxBG;
    private bool unlocked;
    private bool textDisplaying = false;

    SpriteRenderer _sr;
    CapsuleCollider2D _cc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private Text _DialogText;
    [SerializeField] private Text _PromptText;
    [SerializeField] private ItemData _Key;
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
        if (unlocked == true) { DialogBoxBG.SetActive(false); }
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

                        _DialogText.text = "You burn the cobwebs down using the matches.";
                        unlocked = true;
                        textDisplaying = true;
                        
                        _cc.enabled = false;
                        StartCoroutine(waitMethod());
                    }
                    else
                    {
                        _DialogText.text = "I can't get through these cobwebs... I should come back here later.";
                        textDisplaying = true;
                    }


                }
                if (textDisplaying)
                {
                    if (Input.GetKey(KeyCode.Space))
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

    IEnumerator waitMethod() {
        _sr.sprite = newSprite;
        yield return new WaitForSeconds(1.2f);
        _sr.enabled = false;
        GameObject.Find("Cobwebs").SetActive(false);
    }
}
