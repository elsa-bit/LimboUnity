using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Src
{
    public class GameManager
    {
        private static GameManager _instance;
        private Dictionary<GameLevel, Stopwatch> _levelTimers;
        
        private GameManager()
        {
            _levelTimers = new Dictionary<GameLevel, Stopwatch>()
            {
                { GameLevel.One, new Stopwatch() },
                { GameLevel.Two, new Stopwatch() },
                { GameLevel.Three, new Stopwatch() }
            };
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public static GameManager Instance => _instance;
        
        
        public static void Start() => _instance ??= new GameManager();

        public void StartLevelTimer(GameLevel level) => _levelTimers[level].Start();

        public void StopLevelTimer(GameLevel level) => _levelTimers[level].Stop();

        public Dictionary<GameLevel, TimeSpan> GetTimersByLevel()
        {
            var timerByLevel = new Dictionary<GameLevel, TimeSpan>();
            foreach (var key in _levelTimers.Keys)
            {
                timerByLevel[key] =  _levelTimers[key].Elapsed;
            }

            return timerByLevel;
        }
        
    }
}