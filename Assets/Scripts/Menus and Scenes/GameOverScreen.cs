using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    /*
    Function: Restart Level Button
    Purpose: Move to and restarts game level
    */
    public void RestartButton() {
        GameManager.instance.Reset();
    }
    
    /*
    Function: Main Menu Button
    Purpose: Move to main/start menu
    */
    public void MainMenuButton() {
        SceneManager.LoadScene("StartMenu");
    }

    /*
    Function: Quit Button
    Purpose: Close out of game window
    */
    public void QuitGame () {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
