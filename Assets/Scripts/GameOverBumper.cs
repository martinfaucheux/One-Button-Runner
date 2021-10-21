using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBumper : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        GetComponentInParent<PlayerControler>().Die();
    }
}
