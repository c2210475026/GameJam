using UnityEngine;
using static GameManager;

public class ChangePicture : MonoBehaviour
{
    public Sprite openlift;
    public bool flappy;
    public bool doodle;
    public bool dino;

    void Update()
    {
        if(flappy)
        {
            if(FlappyBirdFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
        else if (doodle)
        {
            if (DoodleJumpFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
        else if (dino)
        {
            if (DinoFunFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
    }
}
