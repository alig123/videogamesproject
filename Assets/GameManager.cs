using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameFinished = false;
    public GameObject completeLevelUI;

    public void EndGame()
    {
        if(gameFinished == false)
        {
            gameFinished = true;
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Retry");
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
