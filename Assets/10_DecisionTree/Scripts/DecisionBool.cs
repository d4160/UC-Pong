using UnityEngine;
using System.Collections;

public class DecisionBool : Decision
{
    public bool valueDecision;
    public bool valueTest;

    public override DecisionTreeNode MakeDecision()
    {
        if (valueTest == valueDecision)
            return nodeTrue;
        return nodeFalse;
    }
}