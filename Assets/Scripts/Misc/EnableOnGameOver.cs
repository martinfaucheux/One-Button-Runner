using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnGameOver : MonoBehaviour
{

    void Start()
    {
        GameEvents.instance.onGameOver += EnableChildren;
    }

    void OnDestroy()
    {
        GameEvents.instance.onGameOver -= EnableChildren;
    }

    private void EnableChildren()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }
    }
}
