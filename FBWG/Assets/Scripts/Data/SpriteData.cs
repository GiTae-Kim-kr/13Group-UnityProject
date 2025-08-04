using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Sprite Data", menuName = "Scriptable Object/Data/Sprite Data")]
    public class SpriteData : ScriptableObject
    {
        [SerializeField] private float delay;
        [SerializeField] private Sprite[] sprites;
        public int Length => sprites.Length;
        
        public float Delay => delay;
        
        public Sprite this[int index] => sprites[index];
    }
}