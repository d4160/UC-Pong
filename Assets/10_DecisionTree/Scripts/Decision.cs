public class Decision : DecisionTreeNode
{
    public DecisionTreeNode nodeTrue;
    public DecisionTreeNode nodeFalse;

    public override DecisionTreeNode MakeDecision()
    {
        return nodeTrue;
    }
}