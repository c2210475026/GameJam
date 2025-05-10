using UnityEngine;
using static GameManager;

public class ChangePicture : MonoBehaviour
{
    public Sprite openlift;
    public string game;

    void Update()
    {
        if(game == "flappy")
        {
            if(FlappyBirdFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
        else if (game == "doodle")
        {
            if (DoodleJumpFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
        else if (game == "dino")
        {
            if (DinoFunFinished)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = openlift;
            }
        }
    }
}
