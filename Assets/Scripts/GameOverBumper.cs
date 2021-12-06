using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBumper : MonoBehaviour
{
    public LayerMask whatIsDeath;
    public Health healthComponent;

    void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (whatIsDeath == (whatIsDeath | (1 << layer)))
        {
            Enemy enemyComponent = collider.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                healthComponent.TakeDamage(enemyComponent.collisionDamage);
            }
            else
            {
                healthComponent.Die();
            }
        }
    }


}
