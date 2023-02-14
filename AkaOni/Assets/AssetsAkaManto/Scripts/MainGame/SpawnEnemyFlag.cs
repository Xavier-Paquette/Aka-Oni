using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyFlag : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    private bool _isSpawned;
    // Start is called before the first frame update
    void Start()
    {
        _enemyToSpawn.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && _isSpawned==false)
        {
            _enemyToSpawn.SetActive(true);
            //_enemyToSpawn.GetComponent<EnemyMovement>().ResetPosition();
            _isSpawned = true;
        }
    }

}
