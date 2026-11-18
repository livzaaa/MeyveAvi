using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bananaPrefab;
    public GameObject bombPrefab;
    public GameObject strawberryPrefab;
    public GameObject grapePrefab;
    public GameObject cherryPrefab;
    public GameObject goldenFruitPrefab;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        float currentSpawnRate = Mathf.Clamp(
            0.70f - (ScoreManager.instance.score * 0.002f),
            0.42f,
            0.70f
        );

        if (BonusModeManager.instance != null && BonusModeManager.instance.isBonusMode)
        {
            currentSpawnRate = 0.14f;
        }

        if (timer >= currentSpawnRate)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    void SpawnFruit()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-3.5f, 2.2f), 6f);

        bool bonusMode = BonusModeManager.instance != null && BonusModeManager.instance.isBonusMode;

        GameObject prefab;

        if (bonusMode)
        {
            int bonusRandom = Random.Range(0, 10);

            switch (bonusRandom)
            {
                case 0: prefab = applePrefab; break;
                case 1: prefab = bananaPrefab; break;
                case 2: prefab = strawberryPrefab; break;
                case 3: prefab = grapePrefab; break;
                case 4: prefab = cherryPrefab; break;
                case 5: prefab = applePrefab; break;
                case 6: prefab = strawberryPrefab; break;
                default: prefab = goldenFruitPrefab; break;
            }
        }
        else
        {
            int randomIndex = Random.Range(0, 100);

            if (randomIndex < 7)
            {
                prefab = bombPrefab;
            }
            else if (randomIndex < 11)
            {
                prefab = goldenFruitPrefab;
            }
            else
            {
                int fruitRandom = Random.Range(0, 7);

                switch (fruitRandom)
                {
                    case 0: prefab = applePrefab; break;
                    case 1: prefab = bananaPrefab; break;
                    case 2: prefab = strawberryPrefab; break;
                    case 3: prefab = grapePrefab; break;
                    case 4: prefab = cherryPrefab; break;
                    case 5: prefab = applePrefab; break;
                    default: prefab = strawberryPrefab; break;
                }
            }
        }

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}