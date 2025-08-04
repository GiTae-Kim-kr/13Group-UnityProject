using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Data/Stage Data")]
    public class StageData : ScriptableObject
    {
        [SerializeField] private int count;
        [SerializeField] private float time;
        
        public int Count => count;
        
        public float Time => time;
    }
}