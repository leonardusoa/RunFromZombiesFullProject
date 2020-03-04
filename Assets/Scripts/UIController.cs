using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Script for pause button
    public void PauseButt()
    {
        if(isPaused == false)
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            isPaused = false;
        }
    }

    public void RestartButt()
    {
        isPaused = false;
        Time.timeScale = 1;

        //Loading level with build index
        SceneManager.LoadScene(1);
    }

    public void MenutButt()
    {
        isPaused = false;
        Time.timeScale = 1;

        //Loading level with build index
        SceneManager.LoadScene(0);
    }
}
