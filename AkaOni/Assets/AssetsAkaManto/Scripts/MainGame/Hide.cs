using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    CapsuleCollider2D _cc;
    SpriteRenderer _sr;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CapsuleCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        
    }

    public void EnterHiding() {
        GetComponent<PlayerMovement>().enabled = false;
        _sr.enabled = false;
        _cc.enabled = false;

    }

    public void LeaveLocker() {
        GetComponent<PlayerMovement>().enabled = true;
        _sr.enabled = true;
        _cc.enabled = true;
    }
}
