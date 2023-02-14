using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismanController : MonoBehaviour
{
    private int _count;
    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
    }

    public void AddTalisman() {
        _count++;
    }

    public void GoodEndingCheck() {
        GameOverManager.TalismanCount = _count;
    }
}
