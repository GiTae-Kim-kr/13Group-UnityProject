using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Utils.Input;

namespace Backend.Object
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private int height;
        [SerializeField] private int speed;

        private Rigidbody2D _rigidbody2D;

        private CharacterControls _controls;

        private bool _isJumping;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _controls = new CharacterControls();
        }

        private void OnEnable()
        {
            switch (gameObject.tag)
            {
                case Tag.Player01:
                    _controls.Player01.Enable();
                    _controls.Player01.Move.performed += Move;
                    _controls.Player01.Jump.performed += Jump;
                    _controls.Player01.Move.canceled += Stop;
                    break;
                case Tag.Player02:
                    _controls.Player02.Enable();
                    _controls.Player02.Move.performed += Move;
                    _controls.Player02.Jump.performed += Jump;
                    _controls.Player02.Move.canceled += Stop;
                    break;
                default:
                    break;
            }
        }

        private void Start()
        {
            _rigidbody2D.gravityScale = -Physics2D.gravity.y;
        }

        private void OnDisable()
        {
            switch (gameObject.tag)
            {
                case Tag.Player01:
                    _controls.Player01.Move.performed -= Move;
                    _controls.Player01.Jump.performed -= Jump;
                    _controls.Player01.Move.canceled -= Stop;
                    _controls.Player01.Disable();
                    break;
                case Tag.Player02:
                    _controls.Player02.Move.performed -= Move;
                    _controls.Player02.Jump.performed -= Jump;
                    _controls.Player02.Move.canceled -= Stop;
                    _controls.Player02.Disable();
                    break;
                default:
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            var other = collision2D.gameObject;
            if (other.CompareTag(Tag.Ground))
            {
                _isJumping = false;
            }
        }

        private void OnCollisionExit2D(Collision2D collision2D)
        {
            var other = collision2D.gameObject;
            if (other.CompareTag(Tag.Ground))
            {
                _isJumping = true;
            }
        }

        private void Move(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();

            _rigidbody2D.AddForce(direction * speed, ForceMode2D.Impulse);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_isJumping)
            {
                return;
            }

            var gravity = Physics2D.gravity.y;
            var force = Mathf.Sqrt(2f * gravity * gravity * height);

            _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        private void Stop(InputAction.CallbackContext context)
        {
            var velocity = _rigidbody2D.velocity;

            _rigidbody2D.velocity = new Vector2(0f, velocity.y);
        }
    }
}
