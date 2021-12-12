using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask shurikenLayer;
    public Health healthComponent;
    public int collisionDamage = 1;
    int score = 0;
    public bool destroyOnPlayerCollision = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (healthComponent != null)
        {
            Shuriken shurikenComponent = collider.GetComponent<Shuriken>();
            if (shurikenComponent != null)
            {
                int damage = shurikenComponent.damage;
                bool isDead = healthComponent.TakeDamage(damage);
                if (isDead)
                {
                    Die();
                }
            }
        }

        if (destroyOnPlayerCollision && collider.tag == "Player")
        {
            Die();
        }
    }

    public void Die()
    {
        ScoreManager.instance.Add(score);
        Destroy(gameObject);
    }
}
