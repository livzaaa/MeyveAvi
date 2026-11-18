using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    public int lives = 3;
    public TextMeshProUGUI heartText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetHearts();
    }

    public void LoseLife()
    {
        lives--;

        if (lives < 0)
        {
            lives = 0;
        }

        UpdateHearts();
    }

    public void ResetHearts()
    {
        lives = 3;
        UpdateHearts();
    }

    void UpdateHearts()
    {
        string hearts = "";

        for (int i = 0; i < lives; i++)
        {
            hearts += "♥ ";
        }

        heartText.text = hearts;
    }
}