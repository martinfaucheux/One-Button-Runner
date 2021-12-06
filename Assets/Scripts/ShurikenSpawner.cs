using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public int maxAmount = 1;
    private int _currentAmount = 0;

    public int currentAmount
    {
        get { return _currentAmount; }
        set
        {
            _currentAmount = value;
            GameEvents.instance.ShurikenCountChangeTrigger();
        }
    }

    public bool HasShurikenLeft()
    {
        return currentAmount > 0;
    }
    public void Recharge()
    {
        currentAmount = maxAmount;
    }

    public void Spawn()
    {
        if (HasShurikenLeft())
        {
            Instantiate(shurikenPrefab, transform.position, Quaternion.identity);
            currentAmount--;
        }
    }
}
