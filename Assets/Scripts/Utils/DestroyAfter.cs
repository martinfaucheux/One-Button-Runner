using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyAfterTime = 0f;
    public float maxDistanceToCamera = 0f;
    private float _startTime;

    private Transform _cameraTransform;
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _startTime = Time.time;
    }

    void Update()
    {
        float distanceToCamera = _cameraTransform.position.x - transform.position.x;

        if (
            (destroyAfterTime > 0 && Time.time - _startTime > destroyAfterTime)
            || (maxDistanceToCamera > 0 && distanceToCamera > maxDistanceToCamera)
        )
        {
            Destroy(gameObject);
        }
    }
}
