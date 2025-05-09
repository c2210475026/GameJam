using UnityEngine;
using System.Collections;
using static GameManager;

public class MoveWorld : MonoBehaviour
{
    public float speed = 1f;
    public Transform startPosition;

    void Update()
    {
        if (!FlappyBirdIsDead) {
        transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else {
            // StartCoroutine(ResetWorld());
            ResetWorld();
        }
    }

    void ResetWorld()
    {
        // yield return new WaitForSeconds(2f);
        transform.position = startPosition.position;
    }
}
