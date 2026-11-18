using UnityEngine;
using TMPro;

public class BasketCatch : MonoBehaviour
{
    public GameObject gameOverImage;
    public TextMeshProUGUI finalScoreText;

    public GameObject retryButton;
    public GameObject menuButton;

    public GameObject scorePanel;
    public GameObject canPanel;

    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Banana"))
        {
            ScoreManager.instance.AddScore(2);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GoldenFruit"))
        {
            ScoreManager.instance.AddScore(10);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);

            ScoreManager.instance.ResetCombo();
            LifeManager.instance.LoseLife();

            if (LifeManager.instance.lives <= 0)
            {
                scorePanel.SetActive(false);
                canPanel.SetActive(false);

                gameOverImage.SetActive(true);
                retryButton.SetActive(true);
                menuButton.SetActive(true);

                finalScoreText.text = ScoreManager.instance.score.ToString();

                Time.timeScale = 0f;
            }
        }
    }
}