using System;
using Src;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    void Start()
    {
        var timers = GameManager.Instance.GetTimersByLevel();
        var textComponent = GetComponent<Text>();
        var textScore = String.Empty;
        textScore += $"Level 1 : {timers[GameLevel.One].ToString()}\n";
        textScore += $"Level 2 : {timers[GameLevel.Two].ToString()}\n";
        textScore += $"Level 3 : {timers[GameLevel.Three].ToString()}\n";
        textComponent.text = textScore;
    }
}
