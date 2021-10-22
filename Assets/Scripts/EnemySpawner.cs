using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minY = 0.5f;
    public float maxY = 5;
    public float minInterDistance = 1f;
    public float cameraOffset = 150f;
    public GameObject enemyPrefab;

    private float _moveSpeed;
    private Transform _cameraTransform;
    private float _lastSpawnTime = 0f;

    void Start()
    {
        _moveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().moveSpeed;
        _cameraTransform = Camera.main.transform;

        GameEvents.instance.onGameOver += OnGameOver;
    }

    void OnDestroy()
    {
        GameEvents.instance.onGameOver -= OnGameOver;
    }

    void Update()
    {
        if (Time.time > _lastSpawnTime + minInterDistance / _moveSpeed)
        {
            GameObject.Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
            _lastSpawnTime = Time.time;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        float xPos = _cameraTransform.position.x + cameraOffset;
        float yPos = Random.Range(minY, maxY);
        return new Vector3(xPos, yPos, 0f);
    }

    private void OnGameOver()
    {
        this.enabled = false;
    }
}
