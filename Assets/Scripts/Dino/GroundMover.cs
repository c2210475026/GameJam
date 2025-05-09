using UnityEngine;
using static Manager;

public class GroundMover : MonoBehaviour
{
    public float speed = 5f;
    public Transform startPosition;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (isDead) 
        {
            Restart();
        }
        
    }

    void Restart()
    {
        transform.position = startPosition.position;
        isDead = false;
    
    }
}
