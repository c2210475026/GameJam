using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
        
    }
}
