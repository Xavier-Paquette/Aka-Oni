using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZone : MonoBehaviour
{
  
    protected Vector3 exitPos;


    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) { 
            col.transform.position = exitPos;
        }
    }
}
