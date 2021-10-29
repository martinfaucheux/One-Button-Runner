using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask shurikenLayer;
    int score = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsShuriken(collider))
        {
            ScoreManager.instance.Add(score);
            Destroy(gameObject);
        }
    }

    private bool IsShuriken(Collider2D collider)
    {
        int colliderLayer = collider.gameObject.layer;
        return (shurikenLayer == (shurikenLayer | (1 << colliderLayer)));
    }
}
