using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int combo = 0;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int basePoint)
    {
        combo++;

        int comboBonus = 1;

        if (combo >= 3 && combo < 6)
        {
            comboBonus = 2;
        }
        else if (combo >= 6)
        {
            comboBonus = 3;
        }

        score += basePoint * comboBonus;

        UpdateScoreText();

        if (BonusModeManager.instance != null)
        {
            BonusModeManager.instance.TryActivateBonusMode();
        }
    }

    public void ResetCombo()
    {
        combo = 0;
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}