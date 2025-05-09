using UnityEngine;
using static GameManager;

public class MoveWorld : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        if (!FlappyBirdIsDead) {
        transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
