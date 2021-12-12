using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyAfter = 10f;
    public float _startTime;
    void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _startTime > destroyAfter)
        {
            Destroy(gameObject);
        }
    }
}
