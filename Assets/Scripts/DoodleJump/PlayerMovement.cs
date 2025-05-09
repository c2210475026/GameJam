using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    public GameObject doodleJumpPrefab;
    public Transform startPoint;
    [SerializeField] public AudioSource jumpSound;
    [SerializeField] public AudioSource endSound;
    [SerializeField] public AudioSource resetSound;

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
        rb.AddForce(movementForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            if (doodleJumpPrefab != null)
            {
                endSound.Play();
                doodleJumpPrefab.SetActive(false);
            }
            else
            {
                Debug.LogWarning("DoodleJump_prefab ist nicht zugewiesen!");
            }
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
