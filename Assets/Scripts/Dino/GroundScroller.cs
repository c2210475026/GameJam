using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float speed = 5f;
    public float resetX = -20f;
    private Vector3 startPos;

    
    void Start()
    {
        startPos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= resetX)
        {
            transform.position = startPos;
        }
        
    }
}