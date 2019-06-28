using UnityEngine;
using System.Collections;

public class DecisionBallZPosition : Decision
{
    public Ball ball;
    public Paddle paddle;

    public override DecisionTreeNode MakeDecision()
    {
        if (ball.transform.position.z > paddle.transform.position.z)
            return nodeTrue;

        return nodeFalse;
    }
}