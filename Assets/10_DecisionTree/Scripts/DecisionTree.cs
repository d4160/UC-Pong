public class DecisionTree : DecisionTreeNode
{
    public DecisionTreeNode root;

    private DTAction _actionNew;
    private DTAction _actionOld;

    void Update()
    {
        if (!root) return;

        if (_actionNew)
        {
            _actionNew.activated = false;

            _actionOld = _actionNew;
        }

        var node = MakeDecision();

        while (node is Decision)
        {
            node = node.MakeDecision();
        }

        _actionNew = node as DTAction;

        if (!_actionNew && _actionOld)
            _actionNew = _actionOld;

        if (_actionNew)
            _actionNew.activated = true;
    }

    public override DecisionTreeNode MakeDecision()
    {
        return root.MakeDecision();
    }
}