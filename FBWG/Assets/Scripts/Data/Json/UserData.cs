using System;
using UnityEngine;

namespace Backend.Data.Json
{
    [Serializable]
    public class UserData
    {
        [SerializeField] private StageData[] stages;
        [SerializeField] private float backgroundAudioSourceVolume;
        [SerializeField] private float effectAudioSourceVolume;
        
        public StageData[] Stages { get => stages; set => stages = value; }
        
        public  float BackgroundAudioSourceVolume { get => backgroundAudioSourceVolume; set => backgroundAudioSourceVolume = value; }
        
        public  float EffectAudioSourceVolume { get => effectAudioSourceVolume; set => effectAudioSourceVolume = value; }
    }
}