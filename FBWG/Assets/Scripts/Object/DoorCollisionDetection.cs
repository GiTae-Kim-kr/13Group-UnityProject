using Backend.Utils.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Backend.Object
{
    public class DoorCollisionDetection : CollisionStayedDetection
    {
        private AnimationPlayer _player;

        private ObjectControls _controls;

        private void Awake()
        {
            _controls = new ObjectControls();
            
            _player = GetComponent<AnimationPlayer>();
        }

        protected override void OnTriggerStay2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            _player.Play(0, false);
            
            _controls.Enable();
            _controls.Door.Enter.performed += Enter;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            _player.Play(1, false);
            
            _controls.Door.Enter.performed -= Enter;
            _controls.Disable();
        }

        private void Enter(InputAction.CallbackContext context)
        {
            onEntered.Invoke();
        }
    }
}