using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void exitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}