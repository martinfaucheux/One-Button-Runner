using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance = null;
    public event Action onGameOver;
    public event Action onScoreChange;
    public event Action onShurikenCountChange;

    //Awake is always called before any Start functions
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

    public void GameOverTrigger()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }

    public void ScoreChangeTrigger()
    {
        if (onScoreChange != null)
        {
            onScoreChange();
        }
    }

    public void ShurikenCountChangeTrigger()
    {
        if (onShurikenCountChange != null)
        {
            onShurikenCountChange();
        }
    }

}
