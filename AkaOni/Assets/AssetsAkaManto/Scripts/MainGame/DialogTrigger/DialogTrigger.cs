using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] GameObject DialogBoxBG;
    [SerializeField] private Text _DialogText;
    protected bool _isShowing;
    protected string message = "";
    protected string mc = "Maya";
    protected string friend = "Lily";
    protected string enemy = "Aka Oni";
    protected Collider2D _colObject;
    protected CapsuleCollider2D _cc;
    protected bool firstTime = true;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Enter dialog trigger");
        _colObject = col;
        
        if (_colObject.gameObject.tag == "Player")
        {
            if (firstTime) {
                _colObject.gameObject.GetComponent<PlayerMovement>().enabled = false;
                DialogBoxBG.SetActive(true);
                _isShowing = true;
                _DialogText.text = message + "\n (press space to close)";
                firstTime = false;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        print("Leave dialog trigger");
        
    }

    void Update() {
        if (_isShowing) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogBoxBG.SetActive(false);
                _DialogText.text = "";
                _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                _cc.enabled = false;
                _isShowing = false;
            }
        }

    }
        

}


