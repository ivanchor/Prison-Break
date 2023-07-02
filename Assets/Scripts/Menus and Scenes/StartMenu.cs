using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /*
    Function: Start Button
    Purpose: Move to and restarts game level
    */
    public void PlayButton() {
        SceneManager.LoadScene("InGame");
        GameManager.instance.Reset();
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
