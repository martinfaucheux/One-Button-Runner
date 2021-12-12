using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongAnimator : MonoBehaviour
{
    public int bounces = 3;
    public float amplitude = 10f;
    public float bounceDuration = 0.2f;

    public void Animate()
    {
        // RectTransform rectTransform = (RectTransform)transform;
        Vector3 targetPos = transform.position + amplitude * Vector3.right;
        LeanTween.move(gameObject, targetPos, bounceDuration).setLoopPingPong(bounces);
    }
}
