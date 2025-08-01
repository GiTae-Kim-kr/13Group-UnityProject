using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend.Object
{
    public class ObjectMovement : MonoBehaviour //발판에 붙이는 코드, 움직임 제어
    {
        private Vector3[] _positions;
        private float _time;
        
        private void Awake()
        {
            _positions = new Vector3[2];
            _positions[0] = transform.GetChild(0).position; //하위오브젝트 0번째(발판 시작위치)
            _positions[1] = transform.GetChild(1).position; //발판 종료위치
        }

        private IEnumerator Moving() //발판 움직임
        {
            var time = Time.deltaTime;
            var position = transform.position;
            while (_time <= 1f) //0부터 1 방향
            {
                transform.position = Vector3.Lerp(position, _positions[1], _time);
                _time += time;
                yield return null;
            }
        }

        private IEnumerator Returning() //발판 되돌아감
        {
            var time = Time.deltaTime;
            var position = transform.position;
            while (_time >= 0f) //1부터 0 방향
            {
                transform.position = Vector3.Lerp(_positions[0], position, _time);
                _time -= time;
                yield return null;
            }
        }

        public void Move()
        {
            StopCoroutine(Returning());
            StartCoroutine(Moving());
        }

        public void Return()
        {
            StopCoroutine(Moving());
            StartCoroutine(Returning());
        }
    }
}
