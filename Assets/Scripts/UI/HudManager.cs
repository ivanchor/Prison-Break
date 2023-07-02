using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text scoreLabel;
    public Text moneyLabel;
    public Text healthLabel;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    /*
    Function: Refresh
    Purpose: show palyer stats in HUD
    */
    public void Refresh()
    {
        scoreLabel.text = "Score: " + GameManager.instance.score;
        moneyLabel.text = "Money: " + GameManager.instance.exp;
        healthLabel.text = "Health: " + GameManager.instance.health;
    }
}
