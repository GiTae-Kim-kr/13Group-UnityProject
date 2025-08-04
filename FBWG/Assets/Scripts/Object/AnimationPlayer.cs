using System.Collections;
using UnityEngine;
using Backend.Data;

namespace Backend.Object
{
    public class AnimationPlayer : MonoBehaviour
    {
        [Header("Data Settings")]
        [SerializeField]
        private SpriteData[] data;
        
        private SpriteRenderer _renderer;

        private int _index;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();

            _index = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isLoop"></param>
        public void Play(int index, bool isLoop = false)
        {
            if (_index == index)
            {
                return;
            }

            _index = index;
            
            StopAllCoroutines();
            StartCoroutine(Playing(_index, isLoop));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabled"></param>
        public void Flip(bool isEnabled)
        {
            _renderer.flipX = isEnabled;
        }

        private IEnumerator Playing(int index, bool isLoop)
        {
            var length = data[index].Length;
            var delay = data[index].Delay;
            
            for (var i = 0; i < length; i = isLoop ? (i + 1) % length : i + 1)
            {
                _renderer.sprite = data[index][i];
                
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
