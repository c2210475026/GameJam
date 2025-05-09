using UnityEngine;
using static GameManager;

public class FinishFlappyBird : MonoBehaviour
{

    public GameObject player;

    void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.CompareTag("Player")) {
            EndGame();
        }

    }

    void EndGame() 
    {
        FlappyBirdIsDead = true;
        player.SetActive(false);

    }
}
