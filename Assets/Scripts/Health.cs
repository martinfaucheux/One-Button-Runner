using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 1;
    private int _currentHealth = 1;

    private bool _isPlayer
    {
        get { return gameObject.tag == "Player"; }
    }

    public int maxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int currentHealth
    {
        get { return _currentHealth; }
        private set
        {
            _currentHealth = value;
            if (_isPlayer)
            {
                GameEvents.instance.PlayerHealthChangeTrigger();
            }
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int amount)
    {
        int newAmount = Mathf.Max(currentHealth - amount, 0);
        currentHealth = newAmount;
        if (newAmount == 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public void Die()
    {
        if (gameObject.tag == "Player")
        {
            PlayerControler playerControler = GetComponent<PlayerControler>();
            if (playerControler != null)
            {
                playerControler.Die();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
