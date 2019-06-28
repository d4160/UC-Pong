using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private int _score = 0;

    public event Action<int> OnScoreUpdated;

    public void AddPoints(int points)
    {
        _score += points;

        OnScoreUpdated?.Invoke(_score);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
