using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask shurikenLayer;
    public Health healthComponent;
    int score = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Shuriken shurikenComponent = collider.GetComponent<Shuriken>();
        if (shurikenComponent != null)
        {
            int damage = shurikenComponent.damage;
            bool isDead = healthComponent.TakeDamage(damage);
            if (isDead)
            {
                ScoreManager.instance.Add(score);
                Destroy(gameObject);
            }
        }
    }
}
