using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using static Manager;

public class DinoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float jumpForce = 7f;
    private Rigidbody2D rb;
    public bool isGrounded = true;
    private CapsuleCollider2D capsuleCollider2D;
    public GameObject dino;
    public Transform startPosition;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // test
            Debug.Log("INPUT");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Landed on ground");
        }

        if (collision.gameObject.CompareTag("Cactus"))
        {
            transform.rotation = Quaternion.Euler(0,0,-180);
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            capsuleCollider2D.enabled = false;

            yield return new WaitForSeconds(2f);
             // dino.gameObject.SetActive(false);
            Restart();  
        }
        
    } 

    void Restart() {
        // TODO: restart
        Debug.Log("Restart");
        transform.rotation = Quaternion.identity;
        capsuleCollider2D.enabled = true;
        transform.position = startPosition.position;
        Debug.Log(startPosition.position);
        isDead = true;
        // dino.gameObject.SetActive(true);
    }
}