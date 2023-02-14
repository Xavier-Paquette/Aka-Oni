using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResetFlag : MonoBehaviour
{
    [SerializeField] GameObject _enemy;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _enemy.GetComponent<EnemyMovement>().ResetPosition();
        }
    }

}
