using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;

    public int ScoreValue => _score;

    public event Action<int> OnScoreUpdated;

    public void AddPoints(int points)
    {
        if (points > 0)
        {
            _score += points;

            OnScoreUpdated?.Invoke(_score);
        }
        else
        {
            Debug.LogWarning($"AddPoints(int points): points is lower than 0.");
        }
    }
}
