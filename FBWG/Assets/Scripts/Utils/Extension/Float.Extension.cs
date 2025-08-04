using UnityEngine;

namespace Backend.Utils.Extension
{
    public static class FloatExtension
    {
        public static string ToTimeFormat(this float time)
        {
            var minute = Mathf.FloorToInt(time / 60f);
            var second = Mathf.FloorToInt(time % 60f);
            var millisecond = Mathf.FloorToInt(time * 100f % 100f);
                
            return $"{minute:00}:{second:00}.{millisecond:00}";
        }
    }
}