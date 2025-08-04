using Backend.Data;
using Backend.Utils;
using Backend.Utils.Extension;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Backend.Object
{
    public class GameSystem : MonoBehaviour
    {
        [Header("Debug Information")] 
        [SerializeField] private int score;
        [SerializeField] private int deathCount;

        [Header("Data Settings")]
        [SerializeField] private StageData data;
        
        [Header("UI Settings")]
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;
        [SerializeField] private RawImage[] images;
        
        [Header("Event Callback")]
        [Space(4f)]
        public UnityEvent onGameFinished;

        private Timer _timer;
        
        private int _enteredCount;
        private int _successCount;
        
        private void Awake()
        {
            _timer = GetComponentInChildren<Timer>();
        }

        public void IncrementScore()
        {
            score++;
        }

        public void IncrementDeadCount()
        {
            deathCount++;
        }
        
        public void Enter()
        {
            _enteredCount++;

            if (_enteredCount != 2)
            {
                return;
            }
            
            ApplicationManager.Pause();

            _successCount = 0;
            if (data.Count <= score)
            {
                _successCount++;
            }
                
            if (data.Time >= _timer.Time)
            {
                _successCount++;
            }

            if (deathCount == 0)
            {
                _successCount++;
            }

            for (var i = 0; i < _successCount; i++)
            {
                images[i].enabled = true;
            }

            var index = SceneManager.GetActiveScene().buildIndex - 2;
            DataManager.UserData.Stages[index].Score = _successCount;
            DataManager.UserData.Stages[index + 1].Unlocked = true;
            DataManager.Save();
                
            scoreText.text = score.ToString();
            timeText.text = _timer.Time.ToTimeFormat();
                
            onGameFinished.Invoke();
        }
    }
}