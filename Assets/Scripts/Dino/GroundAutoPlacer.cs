using UnityEngine;

public class GroundAutoPlacer : MonoBehaviour
{
    public GameObject otherGroundPart; // Drag the second ground part here

    void Start()
    {
        if (otherGroundPart == null)
        {
            Debug.LogError("Please assign the other ground part GameObject.");
            return;
        }

        // Get Sprite Renderer and check size
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer found on this GameObject.");
            return;
        }

        // Calculate world width
        float spritePixelWidth = sr.sprite.rect.width;
        float ppu = sr.sprite.pixelsPerUnit;
        float worldWidth = (spritePixelWidth / ppu) * transform.localScale.x;

        // Move the second ground part to the right of this one
        Vector3 newPos = transform.position + new Vector3(worldWidth, 0f, 0f);
        otherGroundPart.transform.position = newPos;
    }
}
