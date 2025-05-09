using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    public float speed = 2f;
    public float groundWidth = 44.44f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // If ground is off screen to the left, reposition to the right
        if (transform.position.x <= -groundWidth)
        {
            transform.position += new Vector3(groundWidth * 2f, 0, 0);
        }
    }
}

