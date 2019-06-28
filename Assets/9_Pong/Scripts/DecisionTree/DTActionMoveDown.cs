using UnityEngine;

public class DTActionMoveDown : DTAction
{
    public Paddle paddle;

    public override void LateUpdate()
    {
        if(!activated)
            return;

        if (paddle)
            paddle.Move(-Vector3.forward);
    }
}

