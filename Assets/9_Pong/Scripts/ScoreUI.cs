using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public Score score;
    public TextMeshPro text;

    private void OnEnable()
    {
        if (score)
            score.OnScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        if (score)
            score.OnScoreUpdated -= OnScoreUpdated;
    }

    private void OnScoreUpdated(int score)
    {
        text.text = score.ToString();
    }
}
