using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuImage;

    public GameObject startButton;
    public GameObject exitButton;

    public GameObject retryButton;
    public GameObject menuButton;

    public GameObject gameOverImage;

    public GameObject scorePanel;
    public GameObject canPanel;

    void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        ResetGameData();

        menuImage.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);

        retryButton.SetActive(false);
        menuButton.SetActive(false);

        gameOverImage.SetActive(false);

        scorePanel.SetActive(true);
        canPanel.SetActive(true);

        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        gameOverImage.SetActive(true);

        retryButton.SetActive(true);
        menuButton.SetActive(true);

        scorePanel.SetActive(false);
        canPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        ResetGameData();

        menuImage.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);

        gameOverImage.SetActive(false);

        retryButton.SetActive(false);
        menuButton.SetActive(false);

        scorePanel.SetActive(true);
        canPanel.SetActive(true);

        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        ResetGameData();
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        menuImage.SetActive(true);

        startButton.SetActive(true);
        exitButton.SetActive(true);

        retryButton.SetActive(false);
        menuButton.SetActive(false);

        gameOverImage.SetActive(false);

        scorePanel.SetActive(false);
        canPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    void ResetGameData()
    {
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.name.Contains("(Clone)"))
            {
                Destroy(obj);
            }
        }

        ScoreManager.instance.score = 0;
        ScoreManager.instance.combo = 0;
        ScoreManager.instance.scoreText.text = "0";

        LifeManager.instance.ResetHearts();

        if (BonusModeManager.instance != null)
        {
            BonusModeManager.instance.ResetBonusMode();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan çıkıldı.");
    }
}