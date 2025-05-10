using System;
using UnityEngine;
using static GameManager;
// using UnityEngine.InputSystem; // Du nutzt aktuell das alte Input System mit GetAxisRaw

public class MainMovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator; // Referenz zum Animator
    private SpriteRenderer spriteRenderer; // Referenz zum SpriteRenderer

    // Start wird einmal beim Start des Scripts aufgerufen
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator Komponente holen
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer Komponente holen

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D nicht am Spieler gefunden!");
            enabled = false;
            return;
        }
        if (animator == null)
        {
            Debug.LogError("Animator nicht am Spieler gefunden!");
            // enabled = false; // Überlege dir, ob das Spiel ohne Animator weiterlaufen soll
        }
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer nicht am Spieler gefunden!");
            enabled = false;
            return;
        }

        rb.gravityScale = 0f;
    }

    // [System.Obsolete] // Entferne dies, wenn Update nicht veraltet sein soll
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // Wert zwischen -1 und 1
        float moveVertical = Input.GetAxisRaw("Vertical");     // Wert zwischen -1 und 1

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.linearVelocity = movement.normalized * moveSpeed;

        // Animator Parameter setzen
        if (animator != null)
        {
            // Setze den 'Speed'-Parameter für horizontale Bewegung (absoluter Wert)
            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            // Setze den 'VerticalSpeed'-Parameter für vertikale Bewegung (behält Vorzeichen bei)
            animator.SetFloat("VerticalSpeed", moveVertical);
        }

        // Sprite spiegeln basierend auf der horizontalen Eingabe
        // Dies sollte nur passieren, wenn NICHT die BackRun_Anim läuft (oder deine BackRun_Anim ist symmetrisch)
        // Für den Moment lassen wir es so, dass gespiegelt wird, wenn man sich links/rechts bewegt,
        // auch wenn man gleichzeitig hoch geht. Wenn BackRun_Anim eine klare Rückansicht ist,
        // sollte das Spiegeln hier keinen störenden Effekt haben.
        if (spriteRenderer != null)
        {
            if (moveHorizontal > 0f) // Bewegung nach rechts
            {
                spriteRenderer.flipX = false; // Nicht spiegeln
            }
            else if (moveHorizontal < 0f) // Bewegung nach links
            {
                spriteRenderer.flipX = true; // Spiegeln
            }
            // Wenn moveHorizontal == 0f, bleibt die letzte Ausrichtung erhalten.
        }
    }

    // Diese Methode wird aufgerufen, wenn dieser Collider/Rigidbody einen anderen Collider/Rigidbody berührt.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüfe, ob das Objekt, mit dem wir kollidiert sind, den Tag "VendingMachine" hat.
        if (collision.gameObject.CompareTag("VendingMachineFlappy") && !FlappyBirdFinished)
        {
            // Wenn ja, gib eine Nachricht in der Konsole aus.
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            // Index = 1 -> Flappy Bird
            index = 1;

            // Hier könntest du in Zukunft weitere Aktionen hinzufügen, z.B. ein UI-Fenster öffnen.
        }
        else if (collision.gameObject.CompareTag("VendingMachineDoodle") && !DoodleJumpFinished)
        {
            // Wenn ja, gib eine Nachricht in der Konsole aus.
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            // Index = 3 -> DoodleJump
            index = 3;

            // Hier könntest du in Zukunft weitere Aktionen hinzufügen, z.B. ein UI-Fenster öffnen.
        }
        else if (collision.gameObject.CompareTag("VendingMachineDino") && !DinoFunFinished)
        {
            // Wenn ja, gib eine Nachricht in der Konsole aus.
            Debug.Log("Spieler ist gegen die Vending Machine gelaufen!");
            // Index = 5 -> DinoFun
            index = 5;

            // Hier könntest du in Zukunft weitere Aktionen hinzufügen, z.B. ein UI-Fenster öffnen.
        }
        else if (collision.gameObject.CompareTag("Elevator"))
        {
            // Wenn ja, gib eine Nachricht in der Konsole aus.
            Debug.Log("Spieler ist gegen die Aufzug gelaufen!");
            // Index = 2 -> MainGame2
            if(index==0 && FlappyBirdFinished){
                index=2;
            }
            // Index = 4 -> MainGame3
            else if(index==2 && DoodleJumpFinished){
                index=4;
            }
            else if(index==4 && DinoFunFinished){
                Debug.Log("GAME FINISHED, you escaped");
            }
            

            // Hier könntest du in Zukunft weitere Aktionen hinzufügen, z.B. ein UI-Fenster öffnen.
        }

        // Du kannst auch den Namen des Objekts ausgeben, mit dem du kollidiert bist, um zu debuggen:
        // Debug.Log("Kollision mit: " + collision.gameObject.name);
    }
}