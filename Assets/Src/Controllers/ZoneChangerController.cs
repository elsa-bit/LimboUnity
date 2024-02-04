using System.Collections;
using System.Collections.Generic;
using Src;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneChangerController : MonoBehaviour
{
    public GameLevel targetLevel;
    public GameLevel currentLevel;
    public GameManagement gameManagement;

    private readonly Dictionary<GameLevel, string> _levelName = new Dictionary<GameLevel, string>()
    {
        { GameLevel.One, "Niveau 1" },
        { GameLevel.Two, "Niveau 2" },
        { GameLevel.Three, "Niveau 3" },
        { GameLevel.End, "ScoreScreen" },
    };
    
    void Start()
    {
        GameManager.Instance.StartLevelTimer(currentLevel);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StopLevelTimer(currentLevel);
            PlayerPrefs.SetFloat("SavedLifePoint", gameManagement.lifePoint);
            PlayerPrefs.Save();
            SceneManager.LoadScene(_levelName[targetLevel]);
        }
    }
}
