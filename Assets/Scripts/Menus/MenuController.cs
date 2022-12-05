using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public GameObject PauseMenu;
    public bool isPaused;
   
    // Update is called once per frame
    void Update()
    { //Pause menu which will activate when the player presses the ESC button
      //The game will stop and the menu will show resume and exit buttons
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
