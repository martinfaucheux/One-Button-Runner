using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask shurikenLayer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsShuriken(collider))
        {
            Destroy(gameObject);
        }
    }

    private bool IsShuriken(Collider2D collider)
    {
        int colliderLayer = collider.gameObject.layer;
        return (shurikenLayer == (shurikenLayer | (1 << colliderLayer)));
    }
}
