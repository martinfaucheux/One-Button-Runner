using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private ShurikenSpawner _shurikenSpawner;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Reward();
            Destroy(gameObject);
        }
    }

    private void Reward()
    {
        ShurikenSpawner.instance.maxAmount += 1;
        ShurikenSpawner.instance.currentAmount += 1;
    }
}
