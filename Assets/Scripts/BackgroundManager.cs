using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform twinBackground;
    public float slideSpeed = 1f;
    private Transform _cameraTransform;
    private float _worldWidth;

    void Start()
    {
        _cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _worldWidth = spriteRenderer.bounds.size.x;

        GameEvents.instance.onGameOver += Stop;
    }

    void OnDestroy()
    {
        GameEvents.instance.onGameOver -= Stop;
    }

    void Update()
    {
        if (NeedDisplacement())
        {
            transform.position = GetNextPosition();
        }
    }

    void FixedUpdate()
    {
        transform.position += slideSpeed * Time.deltaTime * Vector3.right;
    }

    private bool NeedDisplacement()
    {
        float camX = _cameraTransform.position.x;
        float thisX = transform.position.x;
        return (camX - thisX > _worldWidth);
    }

    private Vector3 GetNextPosition()
    {
        return twinBackground.position + (_worldWidth - 0.01f) * Vector3.right;
    }

    private void Stop()
    {
        slideSpeed = 0f;
    }


}
