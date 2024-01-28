using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public int maxLife = 3;
    public float lifePoint = 3f;
    public GameObject[] HeartContainer;
    public GameObject gameOver;

    void Start()
    {
        gameOver.SetActive(false);
        UpdateHeartContainer();
        UpdateLife();
    }

    public void UpdateHeartContainer()
    {
        for (int i = 0; i < maxLife; i++)
        {
            HeartContainer[i].SetActive(true);
        }
        for (int i = maxLife; i < HeartContainer.Length; i++)
        {
            HeartContainer[i].SetActive(false);
        }
    }

    public void UpdateLife()
    {
        int fullhearts = Mathf.FloorToInt(lifePoint);
        for (int i = 0; i < fullhearts; i++)
        {
            HeartContainer[i].GetComponent<HeartContainer>().SetContain(1f);
        }
        if (fullhearts < maxLife)
        {
            if ((lifePoint % fullhearts) != 0)
            {
                HeartContainer[fullhearts].GetComponent<HeartContainer>().SetContain(0.5f);
            }
            else
            {
                HeartContainer[fullhearts].GetComponent<HeartContainer>().SetContain(0f);
            }
        }
        for (int i = fullhearts + 1; i < maxLife; i++)
        {
            HeartContainer[i].GetComponent<HeartContainer>().SetContain(0f);
        }
    }

    public void TakeDamage(float damage)
    {
        lifePoint -= damage;
        UpdateLife();
        if (lifePoint == 0f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
