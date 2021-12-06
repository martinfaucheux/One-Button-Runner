using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public static ShurikenSpawner instance;
    public GameObject shurikenPrefab;
    private int _maxAmount = 1;
    private int _currentAmount = 0;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a CollisionMatrix.
            Destroy(gameObject);
    }

    public int maxAmount
    {
        get { return _maxAmount; }
        set
        {
            _maxAmount = value;
            GameEvents.instance.ShurikenCountChangeTrigger();
        }
    }

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
