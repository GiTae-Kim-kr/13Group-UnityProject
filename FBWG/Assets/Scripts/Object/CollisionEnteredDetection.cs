using UnityEngine;
using UnityEngine.Events;

namespace Backend.Object
{
    public class CollisionEnteredDetection : MonoBehaviour
    {
        [SerializeField] protected ObjectIdentity type;
        
        [Header("Event Callback")]
        [Space(4f)]
        [SerializeField] protected UnityEvent onEntered;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            onEntered.Invoke();
        }
    }
}