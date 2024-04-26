using UnityEngine;

// Require a CharacterController component on the object.
// If no CharacterController component has been attached, it will
// be automatically added.
[RequireComponent(typeof(CharacterController))]

// Place object in a given component bin.
[AddComponentMenu("Control Script/FPS Input")]
    
public class FPSInput : MonoBehaviour
{
    public float _moveSpeed = 6.0f;
    float _jumpSpeed = 10f;
    float _gravity = -50f;
    float _vertSpeed;
    float _minFall = -1f;
    float _terminalVelocity = -4.0f;
        float _groundCheckDistance;
    ControllerColliderHit _contact;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundCheckDistance =
            (_controller.height + _controller.radius) /
            _controller.height * 0.95f;
    }

    public void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * _moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * _moveSpeed;

        Vector3 movement = new(deltaX, 0, deltaZ);

        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _moveSpeed);

        bool hitGround = false;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit)) {
                hitGround = hit.distance <= _groundCheckDistance;
            }

        if (hitGround) {
            if (Input.GetAxis("Jump") != 0) {
                _vertSpeed = _jumpSpeed;
            }
            else
            {
                _vertSpeed = _minFall;
                //_animator.SetBool("Jumping", false);
            }
        }
        else
        {
            _vertSpeed += _gravity * Time.deltaTime;

            if (_vertSpeed < _terminalVelocity)
                _vertSpeed = _terminalVelocity;
            if (_controller.isGrounded)
            {
                
                if (Vector3.Dot(movement, _contact.normal) < 0)
                    movement = _contact.normal * _moveSpeed;
                else
                    movement += _contact.normal * _moveSpeed;
            }
        }


        // Apply gravity after X and Z have been clamped
        // Convert movement vector to rotation settings of player
        movement = transform.TransformDirection(movement);
        movement.y = _vertSpeed;
        ActualMovement(movement);
    }
    public void ActualMovement(Vector3 alpha) {
        _controller.Move(alpha * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }
}
