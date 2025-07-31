using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Backend.Utils.Extension;

namespace Backend.Object
{
    public class CollisionEnteredDetection : MonoBehaviour //들어오는 충돌 감지
    {
        [SerializeField] protected PlayerCharacterType type;
        public UnityEvent onEntered;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                onEntered.Invoke(); //입력만 담당
            }
        }
    }
}
