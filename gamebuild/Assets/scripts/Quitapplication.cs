using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quitapplication : MonoBehaviour
{
    public Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        QuitButton.onClick.AddListener(() => QuitGame());
    }

    // Update is called once per frame
    void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
