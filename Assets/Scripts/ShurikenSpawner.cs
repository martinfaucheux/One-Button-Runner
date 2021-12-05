using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public int maxAmount = 1;
    private int _currentAmount = 0;


    public void Recharge()
    {
        _currentAmount = maxAmount;
    }

    public bool HasShurikenLeft()
    {
        return _currentAmount > 0;
    }

    public void Spawn()
    {
        if (_currentAmount > 0)
        {
            Instantiate(shurikenPrefab, transform.position, Quaternion.identity);
            _currentAmount--;
        }
    }
}
