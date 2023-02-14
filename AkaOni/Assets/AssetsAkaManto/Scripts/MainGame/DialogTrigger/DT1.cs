using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT1 : DialogTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CapsuleCollider2D>();
        message = "What just happened? where is everybody? I have to go find " + friend + "... I hope she's OK...";
    }

    
}
