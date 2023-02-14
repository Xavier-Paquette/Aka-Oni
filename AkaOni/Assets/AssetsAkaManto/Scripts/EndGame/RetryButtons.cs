using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButtons : MonoBehaviour
{
    public void click() {
        SceneManager.LoadScene("MainMenu");
    }
}
