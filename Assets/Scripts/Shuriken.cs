using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 16f;
    public float duration = 1f;

    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time > startTime + duration)
        {
            Die();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * Time.fixedDeltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
