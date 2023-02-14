using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stairs3to2 : MonoBehaviour
{
    protected Vector3 exitPos;
    private bool _inRange;
    Collision2D _colObject;
    [SerializeField]  GameObject DialogBoxBG;
    private bool unlocked;
    private bool textDisplaying = false;
    private bool bagSeen = false;
    SpriteRenderer _sr;
    BoxCollider2D _bc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private Text _DialogText;
   
    // Start is called before the first frame update
    void Start()
    {
        exitPos = new Vector3(19.79f,-34.13f,1);
        _DialogText.text = "";
        _bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && bagSeen)
        {
            col.transform.position = exitPos;
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {

        _inRange = true;
        _colObject = col;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        _inRange = false;
       
        
    }
    void Update()
    {
        if (_inRange)
        {
            if (_colObject.gameObject.tag == "Player")
            {



                if (bagSeen == false)
                {
                    

                    DialogBoxBG.SetActive(true);



                    _DialogText.text = "I have to go find Lily first! she should be in her classroom... \n (Press space to close)";

                    textDisplaying = true;







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
                else { 
                    _bc.enabled = false;
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
    public void DialogSeen() {
        bagSeen = true;
    }
}
