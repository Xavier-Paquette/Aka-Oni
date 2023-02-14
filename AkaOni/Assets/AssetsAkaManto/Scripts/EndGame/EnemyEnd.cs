using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyEnd : MonoBehaviour
{
    [SerializeField] GameObject DialogBoxBG;
    [SerializeField] private Text _DialogText;
    public string PlayerChoice;
    public int TalismanCount;
    [SerializeField] private GameObject _player;
    private Animator _PlayerAnim;
    private SpriteRenderer _sr;
    private bool firstTime = true;
    private bool _isShowing = false;
   
    void Start()
    {
        _PlayerAnim = _player.GetComponent<Animator>();
        _sr = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StopCoroutine(WalkMethod());
            this.GetComponent<Animator>().SetBool("isFacingEast", false);
            if (PlayerChoice.Equals("Blue") && TalismanCount != 5) {
                _player.GetComponent<PlayerMovementEnd>().PlayDeathSound();
                _sr.enabled = false;
                _player.transform.localScale = new Vector3(3,3,3);
                _PlayerAnim.SetBool("isDeadBlue", true);
                print("Bad ending");
                StartCoroutine(BadEndingLoad());
            }
            else if (PlayerChoice.Equals("Red") && TalismanCount != 5)
            {
                _player.GetComponent<PlayerMovementEnd>().PlayDeathSound();
                _player.transform.localScale = new Vector3(3, 3, 3);
                _sr.enabled = false;
                _PlayerAnim.SetBool("isDeadRed", true);
                print("Bad ending");
                StartCoroutine(BadEndingLoad());
            }
            else if (TalismanCount == 5) {
                this.GetComponent<Animator>().SetBool("isDead", true);
                print("Good ending");
                
                StartCoroutine(waitMethod());
            }

        }
    }
    IEnumerator BadEndingLoad() {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("BadEnding");
    }
    IEnumerator waitMethod() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        yield return new WaitForSeconds(7.0f);
        _player.GetComponent<PlayerMovementEnd>().enabled = true;
        GoodEnding();
    }
    private void GoodEnding() {
        
        if (firstTime)
        {
            DialogBoxBG.SetActive(true);
            _isShowing = true;
            _DialogText.text = "Using the 5 talisman I found in the school, I was able to kill the demon!" + "\n (press space to close)";
            firstTime = false;
        }
    }

    public void StartWalk(string PlayerChoice, int TalismanCount) {
        this.PlayerChoice = PlayerChoice;
        this.TalismanCount = TalismanCount;
       
        this.GetComponent<Animator>().SetBool("isFacingEast", true);
        StartCoroutine(WalkMethod());
        
    }

    IEnumerator WalkMethod() {
        Vector3 curPos = transform.position;
        for (int i = 0; i < 275; i++)
        {
            this.transform.position = new Vector3(curPos.x + 0.02f, curPos.y, curPos.z);
            yield return new WaitForSeconds(0.02f);
            curPos = transform.position;
        }

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
                SceneManager.LoadScene("GoodEnding");
            }
        }

    }
}
