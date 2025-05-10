using UnityEngine;

public class InfoPage : MonoBehaviour
{
    public GameObject infoScreen;
    private bool infoShown = true;

    void Start()
    {
        infoScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (infoShown && Input.GetKeyDown(KeyCode.Return))
        {
            infoScreen.SetActive(false);
            infoShown = false;
            Time.timeScale = 1;
        }
    }
}
