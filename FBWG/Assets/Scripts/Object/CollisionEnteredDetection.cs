using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Backend.Utils.Extension;

namespace Backend.Object
{
    public class CollisionEnteredDetection : MonoBehaviour //들어오는 충돌 감지
    {
        [SerializeField] protected ObjectIdentity type;
        public UnityEvent onEntered;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
                
            if (type.HasFlag(component.type)) //HasFlag로 component.type이 type에 포함되어 있는지를 체크함
            {
                onEntered.Invoke(); //입력만 담당
            }
        }
    }
}
