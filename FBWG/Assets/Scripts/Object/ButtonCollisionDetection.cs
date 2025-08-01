using System.Collections;
using System.Collections.Generic;
using Backend.Object;
using UnityEngine;
using Backend.Utils.Extension;

namespace Backend.Object
{
    public class ButtonCollisionDetection : CollisionEnteredDetection //버튼에 붙일 코드, 버튼 상호작용
    {
        private ButtonGroup _group; //private로 변수 선언할때는 _가 국룰

        private void Awake()
        {
            _group = GetComponentInParent<ButtonGroup>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var component = other.GetComponent<ObjectIdentifier>();
                
            if (type.HasFlag(component.type))
            {
                _group.Release();
            }
        }
    }
}
