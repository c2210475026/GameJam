using UnityEngine;
using static GameManager;

public class GameScript : MonoBehaviour
{
    public GameObject[] worlds;
    private int oldIndex = 0;

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
