using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text scoreText;

    private void OnEnable()
    {
        Player.Instance.OnScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        Player.Instance.OnScoreUpdated -= OnScoreUpdated;
    }

    void OnScoreUpdated(int score)
    {
        //Debug.Log($"OnScoreUpdated(int score): score = {score}");
        scoreText.text = score.ToString();
    }
}
