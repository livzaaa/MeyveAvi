using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform[] backgrounds;

    public float scrollSpeed = 2f;
    public float backgroundHeight = 19.2f;

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

            if (bg.position.y < -backgroundHeight)
            {
                float highestY = GetHighestBackgroundY();

                bg.position = new Vector3(
                    bg.position.x,
                    highestY + backgroundHeight,
                    bg.position.z
                );
            }
        }
    }

    float GetHighestBackgroundY()
    {
        float highest = backgrounds[0].position.y;

        foreach (Transform bg in backgrounds)
        {
            if (bg.position.y > highest)
            {
                highest = bg.position.y;
            }
        }

        return highest;
    }
}