using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntityWeight
{
    public GameObject prefab;
    public int weight;

    public float minHeight;
    public float maxHeight;

}

public class EnemySpawner : MonoBehaviour
{
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
            SpawnRandomObject();
        }
    }

    private GameObject SpawnRandomObject()
    {
        EntityWeight entityWeight = ChooseRandomEntity();

        float xPos = _cameraTransform.position.x + cameraOffset;
        float yPos = Random.Range(entityWeight.minHeight, entityWeight.maxHeight);
        Vector3 spawnPos = new Vector3(xPos, yPos, 0f);

        GameObject go = GameObject.Instantiate(entityWeight.prefab, spawnPos, Quaternion.identity);
        _lastSpawnTime = Time.time;
        return go;
    }

    private void OnGameOver()
    {
        this.enabled = false;
    }

    private void SetWeightSum()
    {
        _weightSum = 0;
        foreach (EntityWeight entityWeight in entityWeights)
        {
            _weightSum += entityWeight.weight;
        }
    }

    private EntityWeight ChooseRandomEntity()
    {
        int random = Random.Range(0, _weightSum);
        foreach (EntityWeight entityWeight in entityWeights)
        {
            if (random < entityWeight.weight)
            {
                return entityWeight;
            }
            random -= entityWeight.weight;
        }
        return entityWeights[0];
    }
}
