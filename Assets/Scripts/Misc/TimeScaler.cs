using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    public static TimeScaler instance = null;
    public float freezeDuration;
    private float _originalTimeScale;
    private bool isTimeFrozen = false;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a CollisionMatrix.
            Destroy(gameObject);
    }

    public void Freeze()
    {
        if (!isTimeFrozen)
        {
            isTimeFrozen = true;
            _originalTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            StartCoroutine(UnFreeze());
        }
    }

    private IEnumerator UnFreeze()
    {
        yield return new WaitForSecondsRealtime(freezeDuration);
        Time.timeScale = _originalTimeScale;
        isTimeFrozen = false;
    }


}
