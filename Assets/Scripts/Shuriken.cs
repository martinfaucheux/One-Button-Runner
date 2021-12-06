using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 16f;
    public float duration = 1f;
    public int damage = 1;
    // public Animator slashAnimator;
    public GameObject slashPrefab;

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

        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Die();
    }

    void Die()
    {
        // slashAnimator.SetTrigger("slash");
        Instantiate(slashPrefab, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());

        Destroy(gameObject, 2);
    }
}
