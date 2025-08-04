using UnityEngine;
using UnityEngine.Events;

namespace Backend.Object
{
    public class CollisionStayedDetection : MonoBehaviour
    {
        [SerializeField] protected ObjectIdentity type;
        
        [Header("Event Callback")]
        [Space(4f)]
        public UnityEvent onEntered;
        
        protected virtual void OnTriggerStay2D(Collider2D other)
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
