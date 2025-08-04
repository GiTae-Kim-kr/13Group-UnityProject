using System;
using System.Numerics;
using Backend.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Utils.Input;
using Vector2 = UnityEngine.Vector2;

namespace Backend.Object
{
    public class PlayerCharacterController : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string GroundLayerName = "Ground";

        #endregion
        
        [Header("Movement Settings")]
        [SerializeField] private float height;
        [SerializeField] private float speed;

        [Header("Debug Information")]
        [SerializeField] private bool isJumping;
        [SerializeField] private Vector2 normal;
        
        private AnimationPlayer _animation;
        private ObjectIdentifier _identifier;
        
        private Rigidbody2D _rigidbody2D;

        private CharacterControls _controls;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _animation = GetComponent<AnimationPlayer>();
            _identifier = GetComponent<ObjectIdentifier>();

            _controls = new CharacterControls();
        }

        private void OnEnable()
        {
            switch (_identifier.type)
            {
                case ObjectIdentity.Player01:
                    _controls.Player01.Enable();
                    _controls.Player01.Move.performed += Move;
                    _controls.Player01.Jump.performed += Jump;
                    _controls.Player01.Move.canceled += Stop;
                    break;
                case ObjectIdentity.Player02:
                    _controls.Player02.Enable();
                    _controls.Player02.Move.performed += Move;
                    _controls.Player02.Jump.performed += Jump;
                    _controls.Player02.Move.canceled += Stop;
                    break;
                case ObjectIdentity.None:
                case ObjectIdentity.Block:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FixedUpdate()
        {
            var position = _rigidbody2D.position;
            var origin = new Vector2(position.x, position.y);
            var direction = Vector2.down;
            
            var hit = Physics2D.Raycast(origin, direction, float.MaxValue, LayerMask.GetMask(GroundLayerName));
            if (hit.collider is null)
            {
                return;
            }
            
            isJumping = hit.distance > 0.05f;
            
            if (isJumping)
            {
                _rigidbody2D.gravityScale = -Physics2D.gravity.y;
                
                _animation.Play(2, false);
            }
            else
            {
                _rigidbody2D.gravityScale = 0f;
                
                var x = Mathf.Round(_rigidbody2D.velocity.x * 10f) / 10f;
                
                _animation.Play(x != 0f ? 1 : 0, true);
            }
        }

        private void OnDisable()
        {
            switch (_identifier.type)
            {
                case ObjectIdentity.Player01:
                    _controls.Player01.Move.performed -= Move;
                    _controls.Player01.Jump.performed -= Jump;
                    _controls.Player01.Move.canceled -= Stop;
                    _controls.Player01.Disable();
                    break;
                case ObjectIdentity.Player02:
                    _controls.Player02.Move.performed -= Move;
                    _controls.Player02.Jump.performed -= Jump;
                    _controls.Player02.Move.canceled -= Stop;
                    _controls.Player02.Disable();
                    break;
                case ObjectIdentity.None:
                case ObjectIdentity.Block:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Move(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            var x = direction.x;
            var y = _rigidbody2D.velocity.y;
            
            _animation.Flip(x < 0f);
            
            _rigidbody2D.velocity = new Vector2(x * speed, y);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (isJumping)
            {
                return;
            }
            
            SoundManager.PlayEffectAudioSource(1);
            
            var gravity = Physics2D.gravity.y;
            var force = Mathf.Sqrt(2f * gravity * gravity * height);

            _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        private void Stop(InputAction.CallbackContext context)
        {
            var y = _rigidbody2D.velocity.y;
            
            _rigidbody2D.velocity = new Vector2(0f, y);
        }
    }
}
