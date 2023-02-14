using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT3 : DialogTrigger
{
    GameObject stairs;
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CapsuleCollider2D>();
        message = "That's "+friend+"'s bag! I can't get through all these cobwebs... maybe I can get rid of them somehow?";
        stairs = GameObject.Find("Stairs3to2");
        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            stairs.GetComponent<Stairs3to2>().DialogSeen();
        }
    }
    
}
