using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    [SerializeField] private GameObject _notifCircle = null;
    public ItemData Item
    {
        get
        {
            return _item;
        }
    }
    private bool _inRange;
    private bool collected = false;
    Collision2D _colObject;
    
    [SerializeField] private Text _PromptText;
    void Start()
    {
        if (_PromptText != null) {
            _PromptText.text = "";
        }
        
        string name = this._item.ToString();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        _inRange = true;
        if (col.gameObject.tag == "Player")
        {
            _colObject = col;
        }
        else {
            _colObject = null;
        }
        
    }

        private void OnCollisionExit2D(Collision2D col)
        {
            _inRange = false;
            if (_PromptText != null)
            {
                _PromptText.text = "";
            }
    }

        void Update()
        {
            if (_inRange)
            {
                if (_colObject !=null && _colObject.gameObject.tag == "Player")
                {

                    if (!collected) {
                        if (_PromptText != null)
                        {
                            _PromptText.text = "Press E to add " + name + " to bag";
                        }
                    
                    }

                    if (Input.GetKeyDown(KeyCode.E) && collected==false)
                    {
                        _colObject.gameObject.GetComponent<Player>().AddItem(this.Item);
                        if (_PromptText != null)
                        {
                            _PromptText.text = "";
                        }
                        collected = true;
                        if (name == "Talisman")
                        {
                            AudioSource audio = GetComponent<AudioSource>();
                            audio.Play();

                            GameObject.Find("Player").GetComponent<TalismanController>().AddTalisman();
                        }
                        if (name != "Talisman" && name !="Red Key" && name != "Hammer" && name !="WoodenBoard" && name != "Blue Key" && name !="Cables") { this.gameObject.SetActive(false); }

                        
                        if (_notifCircle != null)
                        {
                            _notifCircle.SetActive(false);
                        }
                    }

                }
            }

        }
 }
