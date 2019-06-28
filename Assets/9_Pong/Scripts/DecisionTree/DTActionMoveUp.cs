using UnityEngine;

public class DTActionMoveUp : DTAction
{
    public Paddle paddle;

    public override void LateUpdate()
    {
        if (!activated)
            return;

        if (paddle)
            paddle.Move(Vector3.forward);
    }
}

