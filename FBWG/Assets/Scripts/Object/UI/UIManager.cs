using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Backend.Object.UI 
{
    public class UIManager : MonoBehaviour
    {
        [Header("Timer UI")]
        [SerializeField] private GameObject gameUIObject;
        [SerializeField] private TMP_Text timerText;

        [Header("Result UI")]
        [SerializeField] private GameObject resultUIObject;
        [SerializeField] private TMP_Text timeCountText;
        [SerializeField] private TMP_Text gemCountText;
        [SerializeField] private TMP_Text scoreCountText;

        private float elapsedTime = 0f;
        private bool isTimerRunning = false;

        // ---------------- Ÿ�̸� ----------------

        public void StartTimer()
        {
            elapsedTime = 0f;
            isTimerRunning = true;
        }

        public void StopTimer()
        {
            isTimerRunning = false;
        }

        public float GetElapsedTime()
        {
            return elapsedTime;
        }

        private void Update()
        {
            if (!isTimerRunning) return;

            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milSeconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);

            timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milSeconds);
        }

        // ---------------- ���â ----------------

        public void ShowResult(int gemCount)
        {
            StopTimer();
            gameUIObject.SetActive(false);
            float timeTaken = GetElapsedTime();

            // �ð� ǥ��
            int minutes = Mathf.FloorToInt(timeTaken / 60f);
            int seconds = Mathf.FloorToInt(timeTaken % 60f);
            int milSeconds = Mathf.FloorToInt((timeTaken * 100f) % 100f);
            timeCountText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milSeconds);

            // ���� ǥ��
            gemCountText.text = gemCount.ToString();

            // ���� ���
            float gemPoint = 500f;
            float timeBase = 10000f;

            float timeScore = Mathf.Clamp(timeBase / timeTaken, 0f, 9999f);
            float gemScore = gemCount * gemPoint;
            float finalScore = timeScore + gemScore;

            scoreCountText.text = Mathf.FloorToInt(finalScore).ToString();

            resultUIObject.SetActive(true);
        }

        public void HideResult()
        {
            resultUIObject.SetActive(false);
        }
    }
}



