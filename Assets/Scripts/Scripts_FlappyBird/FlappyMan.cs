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

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
         if (!FlappyBirdIsDead && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
         }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Here");
        if (collision.gameObject.CompareTag(obstactleTag))
        {
            Death();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpSound.Play();
    }

    void Death()
    {
        if (FlappyBirdIsDead) {return;}

        FlappyBirdIsDead = true;
        deathSound.Play();

        transform.rotation = Quaternion.Euler(0,0,-180);
        rb.linearVelocity = Vector2.zero;
        capsuleCollider2D.enabled = false;
        Destroy(player, destroyTime);
    }
}
