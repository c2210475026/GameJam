using System;
using UnityEngine;
using UnityEngine.Video; // Wichtig für VideoPlayer
using System.Collections;
using static GameManager;

public class MainMovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject video;
    private VideoPlayer videoPlayer;
    public GameObject blackForLevelthree;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null || spriteRenderer == null)
        {
            Debug.LogError("Benötigte Komponente fehlt!");
            enabled = false;
            return;
        }

        rb.gravityScale = 0f;

        if (video != null)
        {
            videoPlayer = video.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached += OnVideoFinished;
            }
            else
            {
                Debug.LogError("VideoPlayer-Komponente nicht gefunden!");
            }
        }
        else
        {
            Debug.LogError("Video-GameObject nicht gesetzt!");
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.linearVelocity = movement.normalized * moveSpeed;

        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
            animator.SetFloat("VerticalSpeed", moveVertical);
        }

        if (spriteRenderer != null)
        {
            if (moveHorizontal > 0f) spriteRenderer.flipX = false;
            else if (moveHorizontal < 0f) spriteRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("VendingMachineFlappy") && !FlappyBirdFinished)
        {
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            index = 1;
        }
        else if (collision.gameObject.CompareTag("VendingMachineDoodle") && !DoodleJumpFinished)
        {
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            index = 3;
        }
        else if (collision.gameObject.CompareTag("VendingMachineDino") && !DinoFunFinished)
        {
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            index = 5;
        }
        else if (collision.gameObject.CompareTag("Elevator"))
        {
            Debug.Log("Spieler ist gegen die Aufzug gelaufen!");

            if(index==0 && FlappyBirdFinished){
                videoIsPlaying = true;
                StartCoroutine(PlayVideo(1));
                index=2;
            }
            else if(index==2 && DoodleJumpFinished){
                videoIsPlaying = true;
                StartCoroutine(PlayVideo(1));
                index=4;
            }
            else if(index==4 && DinoFunFinished){
                // video.SetActive(true);
                videoIsPlaying = true;
                StartCoroutine(PlayVideo(2));
                Debug.Log("GAME FINISHED, you escaped");
                index = 7;
                blackForLevelthree.SetActive(true);
            }
        }
    }

    IEnumerator PlayVideo(int number)
    {
        video.SetActive(true);
        videoPlayer.Play();

        while (!videoPlayer.isPrepared)
            yield return null;

        while (videoPlayer.isPlaying)
            yield return null;
        if (number == 1)
        {
            yield return new WaitForSeconds(8f);
        }else
        {
            yield return new WaitForSeconds(21f);
        }
        
        video.SetActive(false);
        videoIsPlaying = false;

    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video ist zu Ende, deaktiviere GameObject.");
        video.SetActive(false);
    }
}
