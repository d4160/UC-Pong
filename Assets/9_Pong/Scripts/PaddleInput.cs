#define DEBUG_PaddleInput
using UnityEngine;

[RequireComponent(typeof(Paddle))]
public class PaddleInput : MonoBehaviour
{
    private Paddle _paddle;

    private void Awake()
    {
        _paddle = GetComponent<Paddle>();

#if DEBUG_PaddleInput
        Debug.Log("Awake(): Passing for Awake!", gameObject);
#endif
    }

    void Update()
    {
#if !UNITY_ANDROID
        var v = Input.GetAxis("Vertical");

        _paddle.Move(Vector3.forward * v);
#else
        var accel = Input.acceleration;
        _paddle.Move(Vector3.forward * accel.x);
#endif
    }
}
