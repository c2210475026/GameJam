using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovePlayer : MonoBehaviour
{

    public float moveSpeed = 5f; // Geschwindigkeit des Spielers, kann im Inspector angepasst werden

    private Rigidbody2D rb;

    // Start wird einmal beim Start des Scripts aufgerufen
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Holt die Rigidbody2D Komponente vom Spieler GameObject

        // Stelle sicher, dass die Rigidbody2D Komponente existiert
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D nicht am Spieler gefunden!");
            enabled = false; // Deaktiviere das Script, wenn keine Rigidbody2D vorhanden ist
            return;
        }

        // Stelle sicher, dass die Gravitation f�r diesen Rigidbody2D deaktiviert ist
        rb.gravityScale = 0f;
    }

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Lese die Eingabe f�r die horizontale Bewegung (A/D oder Pfeiltasten links/rechts)
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // GetAxisRaw f�r direktere Eingabe ohne Gl�ttung

        // Lese die Eingabe f�r die vertikale Bewegung (W/S oder Pfeiltasten hoch/runter)
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Erstelle einen Bewegungsvektor basierend auf der Eingabe
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalisiere den Bewegungsvektor, damit die diagonale Bewegung nicht schneller ist
        // und multipliziere ihn mit der Bewegungsgeschwindigkeit
        // Time.deltaTime sorgt f�r Frame-unabh�ngige Bewegung
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}