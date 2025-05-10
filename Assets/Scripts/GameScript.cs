using UnityEngine;
using static GameManager;

public class GameScript : MonoBehaviour
{
    //Element 0 = MainGame1
    //Element 1 = FlappyBird
    //Element 2 = MainGame2
    //Element 3 = DoodleJump
    //Element 4 = MainGame3
    //Element 5 = DinoFun
    //Element 9 = Startscreen
    public GameObject[] worlds;
    private int oldIndex = 9;

    void Start()
    {
        worlds[index].SetActive(true);
    }

    void Update()
    {
        if (oldIndex != index) 
        {
            worlds[oldIndex].SetActive(false);
            worlds[index].SetActive(true);
            oldIndex = index;
        }
    }
}
