using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform twinBackground;

    private Transform _cameraTransform;

    private float _worldWidth;

    void Start()
    {
        _cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _worldWidth = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        if (NeedDisplacement())
        {
            transform.position = GetNextPosition();
        }
    }

    private bool NeedDisplacement()
    {
        float camX = _cameraTransform.position.x;
        float thisX = transform.position.x;
        return (camX - thisX > _worldWidth);
    }

    private Vector3 GetNextPosition()
    {
        return twinBackground.position + _worldWidth * Vector3.right;
    }


}
