using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT2 : DialogTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CapsuleCollider2D>();
        message = "What Happened to this place? Why are there massive cracks through the floor? Maybe "+ friend + " is in her classroom... I need to find her...";
    }

    
}
