using System.Collections;
using UnityEngine;

namespace Backend.Object
{
    public class ObjectMovement : MonoBehaviour
    {
        private Vector3[] _positions;
        private float _time;
        
        private void Awake()
        {
            _positions = new Vector3[2];
            _positions[0] = transform.GetChild(0).position;
            _positions[1] = transform.GetChild(1).position;
        }

        private IEnumerator Moving()
        {
            var time = Time.fixedDeltaTime / 4f;
            var position = transform.position;
            while (_time <= 1f)
            {
                transform.position = Vector3.Lerp(position, _positions[1], _time);
                _time += time;
                
                yield return null;
            }
        }

        private IEnumerator Returning()
        {
            var time = Time.fixedDeltaTime / 4f;
            var position = transform.position;
            while (_time >= 0f)
            {
                transform.position = Vector3.Lerp(_positions[0], position, _time);
                _time -= time;
                
                yield return null;
            }
        }

        public void Move()
        {
            StopAllCoroutines();
            StartCoroutine(Moving());
        }

        public void Return()
        {
            StopAllCoroutines();
            StartCoroutine(Returning());
        }
    }
}
