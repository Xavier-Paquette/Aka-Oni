using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;
    private Animator _anim;
    SpriteRenderer _sr;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite blueSprite;
    
    //this value will be taken from introScene, red is just default
    public static string PlayerChoice;
    public void ChoiceCheck() {

        GameOverManager.PlayerChoice = PlayerChoice;
    }
    // Start is called before the first frame update
    void Start()
    {
        print(PlayerChoice);
        _inventory = Instantiate(_inventoryPrefab);
        _anim = GetComponent<Animator>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
       
       
    }
    public void AddItem(ItemData itemToAdd) {
        _inventory.AddItem(itemToAdd);
    }

    public bool FindItem(ItemData item) {
        return _inventory.FindItem(item);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && col is BoxCollider2D)
        {
            StartCoroutine(DieMethod());
           
        }
    }
    IEnumerator DieMethod() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        if (PlayerChoice == "Blue")
        {
            
            _anim.SetBool("isDeadBlue", true);
        }
        else if (PlayerChoice == "Red") {
           
            _anim.SetBool("isDeadRed", true);
        }
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);

        print("died, respawning at last checkpoint");
        this.gameObject.GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerMovement>().Respawn();
        _anim.SetBool("isDeadRed", false);
        _anim.SetBool("isDeadBlue", false);
        _anim.SetBool("isAlive", true);
    }

}
