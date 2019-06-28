using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    public Score scoreTarget;
    public int points = 1;
    public float waitTimeToResetBall = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (scoreTarget)
                scoreTarget.AddPoints(points);

            GameManager.Instance.DestroyBall();
            GameManager.Instance.ResetBallAfter(waitTimeToResetBall);
        }
    }
}
