using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Backend.Object;
using Backend.Utils;
using Backend.Utils.Input;

public class LeverCollisionDetection : CollisionStayedDetection
{
    [Header("Sprite Settings")]
    [SerializeField] private Sprite[] sprites;

    [Header("Event Callback")]
    [Space(4f)]
    public UnityEvent onMove;
    public UnityEvent onReturned;

    private SpriteRenderer _renderer;
 
    private UnityEvent[] _events;

    private ObjectControls _controls;

    private int _index;
    private bool _isDetected;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _renderer.sprite = sprites[0];

        _events = new UnityEvent[2];
        _events[0] = onReturned;
        _events[1] = onMove;

        _controls = new ObjectControls();
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        _controls.Enable();
        _controls.Lever.Toggle.performed += Toggle;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _controls.Lever.Toggle.performed -= Toggle;
        _controls.Disable();
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        SoundManager.PlayEffectAudioSource(0);
        
        _index = (_index + 1) % 2;

        _events[_index].Invoke();
        _renderer.sprite = sprites[_index];
    }
}
