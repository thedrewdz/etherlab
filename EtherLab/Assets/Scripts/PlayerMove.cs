using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4.5f;
    public float gravity = -20f;

    private CharacterController _cc;
    private float _verticalVelocity;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        Vector3 move = (transform.right * h + transform.forward * v);
        move = Vector3.ClampMagnitude(move, 1f) * moveSpeed;

        if (_cc.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = -2f; // keeps grounded

        _verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move + Vector3.up * _verticalVelocity;
        _cc.Move(velocity * Time.deltaTime);
    }
}