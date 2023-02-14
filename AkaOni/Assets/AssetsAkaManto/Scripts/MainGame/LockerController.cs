using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerController : MonoBehaviour
{
    private bool _inRange = false;
    private bool insideLocker;
    Collision2D _colObject;
    [SerializeField] private Text _PromptText;
    void Start() {
        _PromptText.text = "";
        
    }
    private void OnCollisionEnter2D(Collision2D col) {
        _inRange = true;
        if (_colObject.gameObject.tag == "Player") {
            _colObject = col;
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        _inRange = false;
        _colObject = null;
        _PromptText.text = "";
    }

    void Update() {
        if (_inRange) {
            if (_colObject.gameObject.tag == "Player" && _colObject.gameObject.tag != "Enemy")
            {
                if (!insideLocker) { _PromptText.text = "Press E to hide in Locker"; }
               
                if (Input.GetKey(KeyCode.E))
                {
                    _colObject.gameObject.GetComponent<Hide>().EnterHiding();
                    _PromptText.text = "Press R to exit the Locker";
                    insideLocker = true;
                }
                if (insideLocker)
                {
                    if (Input.GetKey(KeyCode.R)) {
                        _colObject.gameObject.GetComponent<Hide>().LeaveLocker();
                        insideLocker = false;
                    }
                }
            }
        }

        
    }
}
