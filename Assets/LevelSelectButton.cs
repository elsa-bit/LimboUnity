using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public string levelName;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void changeScene() {
        SceneManager.LoadScene(levelName);
    }
}
