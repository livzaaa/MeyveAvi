using UnityEngine;

public class FruitFall : MonoBehaviour
{
    public float baseFallSpeed = 3f;

    void Update()
    {
        float extraSpeed = ScoreManager.instance.score * 0.015f;

        float fallSpeed = Mathf.Clamp(
            baseFallSpeed + extraSpeed,
            3.8f,
            6.8f
        );

        if (CompareTag("Bomb"))
        {
            fallSpeed += 0.8f;
        }

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}