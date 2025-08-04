using Backend.Utils;
using UnityEngine;

namespace Backend.Object
{
    public class ButtonCollisionDetection : CollisionStayedDetection
    {
        [Header("Sprite Settings")]
        [SerializeField] private Sprite[] sprites;
        
        private SpriteRenderer _renderer;
        
        private ButtonGroup _group;

        private void Awake()
        {
            _renderer = GetComponentInChildren<SpriteRenderer>();
            _renderer.sprite = sprites[0];
            
            _group = GetComponentInParent<ButtonGroup>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            SoundManager.PlayEffectAudioSource(0);
        }

        protected override void OnTriggerStay2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            _renderer.sprite = sprites[1];
            
            _group.Press();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            SoundManager.PlayEffectAudioSource(0);
            
            _renderer.sprite = sprites[0];
                
            _group.Release();
        }
    }
}
