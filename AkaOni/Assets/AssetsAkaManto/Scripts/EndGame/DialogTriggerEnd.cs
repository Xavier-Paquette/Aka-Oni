using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogTriggerEnd : MonoBehaviour
{
    [SerializeField] GameObject DialogBoxBG;
    [SerializeField] private Text _DialogText;
    protected bool _isShowing;
    protected string message = "I finally made it out! I hope Lily is ok...";
    protected string mc = "Maya";
    protected string friend = "Lily";
    protected string enemy = "Aka Oni";
    protected Collider2D _colObject;
    protected bool firstTime = true;
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Enter dialog trigger");
        _colObject = col;

        if (_colObject.gameObject.tag == "Player")
        {
            if (firstTime)
            {
                DialogBoxBG.SetActive(true);
                _isShowing = true;
                _DialogText.text = message + "\n (press space to close)";
                firstTime = false;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        print("Leave dialog trigger");

    }

    void Update()
    {
        if (_isShowing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogBoxBG.SetActive(false);
                _DialogText.text = "";
                _isShowing = false;
            }
        }

    }
}
