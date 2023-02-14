using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static string PlayerChoice;
    public static int TalismanCount;
    private string defeatMessage;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    private Animator _PlayerAnim;
   
    // Start is called before the first frame update
    void Start()
    {
        print("Player choice: " + PlayerChoice + "\n TalismanCount: " + TalismanCount);
        _PlayerAnim = _player.GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            EndingCutscene();

        }
    }

    public void EndingCutscene()
    {
        _player.GetComponent<PlayerMovementEnd>().StopMoving();
        _player.GetComponent<PlayerMovementEnd>().enabled = false;
        _enemy.GetComponent<EnemyEnd>().StartWalk(PlayerChoice, TalismanCount);
       

    }

}
