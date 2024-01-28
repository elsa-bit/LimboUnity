using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    private float contain = 0f;
    public GameObject[] Hearts;

    public float GetContain()
    {
        return contain;
    }

    public void SetContain(float newContain)
    {
        contain = newContain;
        UpdateLife();
    }

    private void UpdateLife()
    {
        if (contain == 0)
        {
            Hearts[0].SetActive(false);
            Hearts[1].SetActive(false);
        }
        else if (contain == 0.5f)
        {
            Hearts[0].SetActive(false);
            Hearts[1].SetActive(true);
        }
        else if (contain == 1f)
        {
            Hearts[0].SetActive(true);
            Hearts[1].SetActive(false);
        }
    }
}
