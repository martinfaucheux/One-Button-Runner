using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBumper : MonoBehaviour
{
    public LayerMask whatIsDeath;

    void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (whatIsDeath == (whatIsDeath | (1 << layer)))
        {
            GetComponentInParent<PlayerControler>().Die();
        }
    }


}
