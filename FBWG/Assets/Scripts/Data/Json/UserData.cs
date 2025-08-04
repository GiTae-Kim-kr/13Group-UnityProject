using System;
using UnityEngine;

namespace Backend.Data.Json
{
    [Serializable]
    public class UserData
    {
        [SerializeField] private StageData[] stages;
        
        public StageData[] Stages { get => stages; set => stages = value; }
    }
}