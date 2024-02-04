using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public int maxLife = 3;
    public float lifePoint = 3f;
    public GameObject orbeIndicator;
    public GameObject[] HeartContainer;
    public GameObject[] orbes;
    public GameObject currentOrbe = null;
    public GameObject gameOver;
    public GameObject player;
    public Button son;
    public Sprite SonOn;
    public Sprite SonOff;
    private bool muted;

    void Start()
    {
        gameOver.SetActive(false);

        var _savedLife = PlayerPrefs.GetFloat("SavedLifePoint");
        if (_savedLife != 0f)
        {
            lifePoint = PlayerPrefs.GetFloat("SavedLifePoint");
            PlayerPrefs.SetFloat("SavedLifePoint", 0f);
        }

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
            if (lifePoint < 0f && fullhearts < 0)
            {
                GameOver();
            }
            else
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

    public void GainLife(float lifeAmount)
    {
        lifePoint += lifeAmount;
        UpdateLife();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        player.SetActive(false);
        lifePoint = (float)maxLife;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Mute()
    {
        muted = !muted;
        if (muted)
        {
            AudioListener.volume = 0;
            son.image.sprite = SonOff;
        }
        else
        {
            AudioListener.volume = 1;
            son.image.sprite = SonOn;
        }
    }

    public bool IsOrbeType(GameObject o) {
        foreach (var orbe in orbes)
        {
            if (orbe.CompareTag(o.tag)) {
                return true;
            }
        }
        return false;
    }

    public void UpdateSelectedOrbe(string tag) {
        foreach (var orbe in orbes)
        {
            if (orbe.CompareTag(tag)) {
                currentOrbe = orbe;
                orbeIndicator.SetActive(true);
                return;
            }
        }
        orbeIndicator.SetActive(false);
    }
}
