using UnityEngine;
public class BasketController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float minX = -7f;
    public float maxX = 7f;

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }

        transform.position += Vector3.right * move * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);

        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
    }
}