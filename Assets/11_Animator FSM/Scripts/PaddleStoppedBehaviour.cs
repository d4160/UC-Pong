using UnityEngine;

public class PaddleStoppedBehaviour : StateMachineBehaviour
{
    private Paddle _paddle;
    private Ball _ball;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_paddle)
            _paddle = animator.GetComponent<Paddle>();

        if (!_ball)
            _ball = GameManager.Instance.PlayingBall;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Condition 1
        if ((_paddle.isRight && _ball.IsGoingToRight) ||
            (!_paddle.isRight && !_ball.IsGoingToRight))
        {
            animator.SetBool("BallToHere", true);
            animator.SetBool("BallAbove", _ball.IsAboveInZAxis(_paddle.transform.position));

            return;
        }

        // Act
        if (_paddle)
            _paddle.Move(Vector3.zero);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
