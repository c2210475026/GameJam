using UnityEngine;
using System.Collections;
using static GameManager;

[RequireComponent(typeof(Rigidbody2D))]
public class FlappyMan : MonoBehaviour {
    
    public GameObject player;
    const string obstactleTag = "Obstacle";
    const string playerTag = "Player";
    public float jumpForce = 2f;
    private float destroyTime = 2f;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    private CapsuleCollider2D capsuleCollider2D;

    public Transform startPoint;
    public bool canMove = true;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
         if (canMove && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
         }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Here");
        if (collision.gameObject.CompareTag(obstactleTag))
        {
            StartCoroutine(Death());
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpSound.Play();
    }

    IEnumerator Death()
    {
        deathSound.Play();
        canMove = false;

        // Todeseffekt: drehen, Bewegung stoppen, Collider deaktivieren
        transform.rotation = Quaternion.Euler(0, 0, -180);
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        capsuleCollider2D.enabled = false;

        // Physik ausschalten, damit keine Bewegung mehr stattfindet
        // rb.simulated = false;

        // Warten (z. B. für Animation/Sound)
        yield return new WaitForSeconds(destroyTime);
        FlappyBirdIsDead = true;

        rb.simulated = false;


        // Spieler zurücksetzen
        transform.position = startPoint.position;
        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(0,0,-21);

        yield return new WaitForSeconds(0.5f);

        // Physik und Collider wieder aktivieren
        rb.simulated = true;
        Jump();
        capsuleCollider2D.enabled = true;

        FlappyBirdIsDead = false;
        canMove = true;
    }
}
