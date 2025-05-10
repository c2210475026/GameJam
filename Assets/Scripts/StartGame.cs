using UnityEngine;
using static GameManager;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            index = 0;
        }
    }
}
