using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask shurikenLayer;
    public Health healthComponent;
    public int collisionDamage = 1;
    public int score = 0;
    public bool destroyOnPlayerCollision = false;
    public bool canTakeDamage = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (healthComponent != null)
        {
            if (canTakeDamage)
            {
                Shuriken shurikenComponent = collider.GetComponent<Shuriken>();
                if (shurikenComponent != null)
                {
                    int damage = shurikenComponent.damage;
                    bool isDead = healthComponent.TakeDamage(damage);
                }
            }

            if (destroyOnPlayerCollision && collider.tag == "Player")
            {
                healthComponent.Die();
            }
        }
    }

    public void OnDeath()
    {
        ScoreManager.instance.Add(score);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
