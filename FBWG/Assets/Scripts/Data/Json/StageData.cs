using System;
using UnityEngine;

namespace Backend.Data.Json
{
    [Serializable]
    public class StageData
    {
        [SerializeField] private int score;
        [SerializeField] private bool unlocked = true;
        
        public int Score { get => score; set => score = value; }
        
        public bool Unlocked { get => unlocked; set => unlocked = value; }
    }
}