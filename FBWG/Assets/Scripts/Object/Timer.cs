using System.Collections;
using Backend.Utils.Extension;
using UnityEngine;
using UnityEngine.UI;

namespace Backend.Object
{
    public class Timer : MonoBehaviour
    {
        [Header("UI Settings")]
        [SerializeField] private Text text;
        
        private IEnumerator Running()
        {
            while (true)
            {
                text.text = Time.ToTimeFormat();
                
                Time += UnityEngine.Time.deltaTime;
                
                yield return null;
            }
        }

        public void Run()
        {
            StartCoroutine(Running());
        }

        public void Stop()
        {
            StopAllCoroutines();
        }

        public float Time { get; private set; }
    }
}