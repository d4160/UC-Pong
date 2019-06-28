public class DecisionBallXDirection : Decision
{
    public Ball ball;

    public override DecisionTreeNode MakeDecision()
    {
        if (ball.Rb.velocity.x > 0)
            return nodeTrue;

        return nodeFalse;
    }
}