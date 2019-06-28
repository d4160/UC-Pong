using UnityEngine;
using System.Collections;

public class DecisionFloat : Decision
{
    public float valueMin;
    public float valueMax;
    public float valueTest;

    public override DecisionTreeNode MakeDecision()
    {
        if (valueMax <= valueTest && valueTest >= valueMin)
            return nodeTrue;

        return nodeFalse;
    }
}