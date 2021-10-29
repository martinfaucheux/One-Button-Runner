
using UnityEngine;
using TMPro;
public class ScoreUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        GameEvents.instance.onScoreChange += UpdateUI;
    }
    void OnDestroy()
    {
        GameEvents.instance.onScoreChange -= UpdateUI;
    }

    void UpdateUI()
    {
        int score = ScoreManager.instance.score;
        text.text = score.ToString();
    }
}
