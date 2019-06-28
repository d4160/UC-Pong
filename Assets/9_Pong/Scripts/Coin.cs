using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 5;

    private void OnTriggerEnter(Collider other)
    {
        var score = other.GetComponentInParent<Score>();
        if (score)
        {
            score.AddPoints(points);
        }

        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
