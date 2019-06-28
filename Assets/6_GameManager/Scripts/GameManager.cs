using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Ball _playingBall;

    public Ball PlayingBall => _playingBall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                DestroyImmediate(this.gameObject);
            }
        }
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);
    }

    public void ResetBallAfter(float seconds = 0.0f)
    {
        if (seconds > 0)
            Invoke("ResetBall", seconds);
        else
            ResetBall();
    }

    private void ResetBall()
    {
        if (_playingBall)
        {
            _playingBall.Reset();
        }
    }

    public void DestroyBall()
    {
        if (_playingBall)
        {
            _playingBall.Destroy();
        }
    }
}