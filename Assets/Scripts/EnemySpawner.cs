using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntityWeight
{
    public GameObject prefab;
    public int weight;

}

public class EnemySpawner : MonoBehaviour
{
    public float minY = 0.5f;
    public float maxY = 5;
    public float minInterDistance = 1f;
    public float cameraOffset = 150f;
    public EntityWeight[] entityWeights;
    private int _weightSum;
    private Transform _cameraTransform;
    private float _lastSpawnTime = 0f;

    void Start()
    {
        _cameraTransform = Camera.main.transform;
        SetWeightSum();


        GameEvents.instance.onGameOver += OnGameOver;
    }

    void OnDestroy()
    {
        GameEvents.instance.onGameOver -= OnGameOver;
    }

    void Update()
    {
        if (Time.time > _lastSpawnTime + minInterDistance / GameManager.instance.gameSpeed)
        {
            GameObject prefab = ChooseRandomEntity();
            GameObject.Instantiate(prefab, GetSpawnPosition(), Quaternion.identity);
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

    private void SetWeightSum()
    {
        foreach (EntityWeight entityWeight in entityWeights)
        {
            _weightSum += entityWeight.weight;
        }
    }

    private GameObject ChooseRandomEntity()
    {
        int random = Random.Range(0, _weightSum);
        foreach (EntityWeight entityWeight in entityWeights)
        {
            if (random < entityWeight.weight)
            {
                return entityWeight.prefab;
            }
            random -= entityWeight.weight;
        }
        return null;
    }
}
