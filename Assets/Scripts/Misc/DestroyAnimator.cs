using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimator : MonoBehaviour
{

    public Vector3 positionOffset;
    public float angle;
    public float animDuration = 1f;



    public void Animate()
    {

        Vector3 targetPosition = transform.position + positionOffset;
        LeanTween.move(gameObject, targetPosition, animDuration).setEaseInCubic();
        LeanTween.alpha(gameObject, 0f, animDuration).setEaseInCubic();
        LeanTween.rotateZ(gameObject, angle, animDuration);
    }

}
