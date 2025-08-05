using UnityEngine;

namespace Backend.Object
{
    public class ObjectToggle : CollisionStayedDetection
    {
        [Header("Game Object Settings")]
        [SerializeField] private GameObject instance;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            instance?.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            instance?.SetActive(false);
        }
    }
}