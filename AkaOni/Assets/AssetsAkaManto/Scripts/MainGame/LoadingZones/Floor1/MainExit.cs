using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            col.GetComponent<TalismanController>().GoodEndingCheck();
            col.GetComponent<Player>().ChoiceCheck();
            SceneManager.LoadScene("EndScene");
        }
    }
}
