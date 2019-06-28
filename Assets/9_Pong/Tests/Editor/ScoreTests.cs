using NUnit.Framework;
using UnityEngine;

public class ScoreTests
{
    private Score _score;

    [SetUp]
    public void SetUp()
    {
        _score = new GameObject("ScoreTests").AddComponent<Score>();
    }

    [Test]
    public void CheckScore_ValidPointsValue_Test()
    {
        // Arrange
        var points = 7;

        // Act
        _score.AddPoints(points);

        // Assert
        Assert.True(_score.ScoreValue == points);
    }

    [Test]
    public void CheckScore_InvalidPointsValue_Test()
    {
        // Arrange
        var points = -7;

        // Act
        _score.AddPoints(points);

        // Assert
        Assert.True(_score.ScoreValue == 0);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(_score.gameObject);
    }
}
