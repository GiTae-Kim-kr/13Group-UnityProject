using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Audio Clip Data", menuName = "Scriptable Object/Data/Audio Clip Data")]
    public class AudioClipData : ScriptableObject
    {
        [SerializeField] private AudioClip[] clips;
        
        public int Length => clips.Length;
        
        public AudioClip this[int index] => clips[index];
    }
}