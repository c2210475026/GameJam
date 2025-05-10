using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    public Transform startPoint;
    public AudioSource jumpSound;
    public AudioSource endSound;
    public AudioSource resetSound;
    public GameObject player;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Eingabe lesen
        float moveHorizontal = Input.GetAxis("Horizontal");

        Debug.Log(moveHorizontal);
        Vector2 movementForce = new Vector2(moveHorizontal, 0);
        rb.AddForce(movementForce*moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            endSound.Play();
            player.SetActive(false);
            DoodleJumpFinished = true;
            index = 2; //HIER INDEX AUF MAIN GAME LEVEL 2 aendern
        }
        else if (collision.collider.CompareTag("edge"))
        {
            resetSound.Play();
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.position = startPoint.position;
        }
        else if (collision.collider.CompareTag("Boxes"))
        {
            jumpSound.Play();
        }
    }
}
