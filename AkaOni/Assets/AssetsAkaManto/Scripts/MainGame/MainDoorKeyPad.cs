using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainDoorKeyPad : MonoBehaviour
{
    private bool _inRange;
    Collider2D _colObject;
    private bool unlocked;
    CapsuleCollider2D _cc;//hitbox just used to stop player from walking thru, turned off once door is unlocked
    [SerializeField] private GameObject _KeypadCanvas;
    [SerializeField] private Text _currentGuess;
    [SerializeField] private Text _PromptText;
    private string[] inputArr = new string[] {null,null,null,null};
    string[] answerArr = new string[] { "1", "9", "9", "8"};
    [SerializeField] private GameObject _MainDoor;
    private bool _promptTextShown = false;
    void Start()
    {
        
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
        _promptTextShown = false;
        _PromptText.text = "";
        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
    }

    void Update()
    {
        if (_inRange)
        {
            if (_colObject.gameObject.tag == "Player")
            {
                if (_promptTextShown == false)
                {
                    _PromptText.text = "Press E to inspect the keypad";

                }
                else {
                    _PromptText.text = "";
                }
                
                if (Input.GetKey(KeyCode.E))
                {
                    _promptTextShown = true;
                    _KeypadCanvas.SetActive(true);
                    _colObject.gameObject.GetComponent<PlayerMovement>().enabled = false;
                 
                    
                }
                if (Input.GetKey(KeyCode.Escape)) {
                    _promptTextShown = true;
                    _KeypadCanvas.SetActive(false);
                    _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;
                }
               
            }
        }
    }
    public void One() {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5) {
            for (int i = 0; i < inputArr.Length; i++) {
                if (inputArr[i] == null) {
                    inputArr[i] = "1";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Two()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "2";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Three()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "3";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Four()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "4";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Five()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "5";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Six()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "6";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Seven()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "7";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Eight()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "8";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Nine()
    {
        if (_currentGuess.text.Equals("Wrong")) { _currentGuess.text = ""; }
        if (inputArr.Length < 5)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == null)
                {
                    inputArr[i] = "9";
                    _currentGuess.text += inputArr[i];
                    break;
                }
            }
        }
    }
    public void Enter()
    {
        int correct = 0;
        for (int i = 0; i < inputArr.Length; i++)
        {
            if (inputArr[i] != null && inputArr[i].Equals(answerArr[i])) {
                correct++;
            }
        }
        if (correct == 4)
        {
            _MainDoor.GetComponent<MainDoor>().Solve();
            StartCoroutine(waitMethodCorrect());

        }
        else {
            StartCoroutine(waitMethodWrong());
        }
        
    }

    public void Clear(){
        for (int i = 0; i < inputArr.Length; i++)
        {
            inputArr[i] = null;
            _currentGuess.text = "";
        }
    }
    IEnumerator waitMethodCorrect()
    {
        _currentGuess.text = "Correct";
        yield return new WaitForSeconds(1.2f);
        _KeypadCanvas.SetActive(false);
        _colObject.gameObject.GetComponent<PlayerMovement>().enabled = true;

    }
    IEnumerator waitMethodWrong()
    {
        _currentGuess.text = "Wrong";
        yield return new WaitForSeconds(2);
        Clear();

    }
}
