using System;
using System.Collections.Generic;
using UnityEngine;

namespace Backend.Object
{
    public class MudCollisionDetection : CollisionEnteredDetection
    {
        [Header("Game Object Information")] 
        [SerializeField] private PositionInformation[] positions;
        
        private Dictionary<ObjectIdentity, PositionInformation> _positions;
        
        private void Awake()
        {
            _positions = new Dictionary<ObjectIdentity, PositionInformation>
                         {
                             { ObjectIdentity.Player01, positions[0] },
                             { ObjectIdentity.Player02, positions[1] }
                         };
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
            if (type.HasFlag(component.type) == false)
            {
                return;
            }
            
            onEntered.Invoke();

            _positions[component.type].current.position = _positions[component.type].origin;
        }
        
        #region SERIALIZABLE STRUCTURE API

        [Serializable]
        private struct PositionInformation
        {
            public Vector3 origin;
            public Transform current;
        }

        #endregion
    }
}