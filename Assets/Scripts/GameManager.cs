using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Static instance of the Game Manager, can be accessed from anywhere
    public static GameManager instance = null;
    
    //Player Score
    public int score = 0;

    //Player Health, 100 base health
    public int health = 100;

    //Player Level, 1 base level
    public int level = 1;

    public int exp = 0;

    public int buyPrice = 10;
    public bool hasKnife = false;
    public bool hasKatana = true;
    public bool hasLaser = false;
    public bool hasTaser = false;
    private int knifeUpgrades = 5;
    private int katanaUpgrades = 5;
    private int laserUpgrades = 5;
    private int taserUpgrades = 5;
    private int DurationUpgrades = 3;
    private int SpeedUpgrades = 3;
    private int ProjSpeedUpgrades = 3;
    private int DamageUpgrades = 3;
    // public GameObject player = PlayerMove;

    public void setHealth(int amt)
    {
        health = amt;
    }

    public int getHealth()
    {
        return health;
    }
    
    /*
    Function: Awake
    Purpose: essentially waking up the game.
    */
    void Awake()
    {
        //if it doesn't exist
        if(instance == null)
        {
            //Set the instance too the current object(this)
            instance = this;
        }


        //There can only be a single instance of the game manager
        else if(instance!=this)
        {
            //Destory the current object, so that there is just one manager
            Destroy(gameObject);
        }

        //Don't Destroy this object when loading scenes
        DontDestroyOnLoad(gameObject);
    }

    /*
    Function: IncreaseScore
    Purpose: increases Score, prints new amount in console.
    */
    public void IncreaseScore(int amount)
    {
        //Increase the score by the given amount
        score += amount;

        //Show new score amount in the console
        print("New score: " + score.ToString());
    }

    /*
    Function: DecreaseHealth
    Purpose: decreases health, prints new amount in console.
    */
    public void DecreaseHealth(int amount)
    {
        health -= amount;

        print("New health: " + health.ToString());
    }

    /*
    Function: IncreaseLevel
    Purpose: increases level, prints new amount in console.
    */
    public void IncreaseLevel(int amount)
    {
        level += amount;

        print("New level: " + level.ToString());
    }

    /*
    Function: IncreaseExp
    Purpose: increases exp, prints new amount in console.
    */
    public void IncreaseExp(int amount)
    {
        exp += amount;

        print("Exp level: " + exp.ToString());
    }

    /*
    Function: reset
    Purpose: restarts the game, setting score to 0 and going back to level 1
    */
    public void Reset()
    {
        //reset score
        score = 0;

        //reset money
        exp = 0;

        //reset health
        health = 100;

        buyPrice = 10;
        hasKnife = false;
        hasKatana = true;
        hasLaser = false;
        hasTaser = false;
        knifeUpgrades = 5;
        katanaUpgrades = 5;
        laserUpgrades = 5;
        taserUpgrades = 5;
        DurationUpgrades = 3;
        SpeedUpgrades = 3;
        ProjSpeedUpgrades = 3;
        DamageUpgrades = 3;

        //Loard corresponding scene (level 1 or "splash screen" scene)
        SceneManager.LoadScene("InGame");
    }

    public void BuyLaser(GameObject player)
    {
        
        if (buyPrice < exp && laserUpgrades > 0)
        {
            if(hasLaser)
            {
                //upgrade laser by decreasing the cd time by -0.1
                player.gameObject.SendMessage("increaseLaserCDTime", -0.05);
                laserUpgrades--;
                buyPrice += 5;
            }
            else
            {
                player.gameObject.SendMessage("SetLaser", true);
                hasLaser = true;
            }
            exp -= buyPrice;
            print("buyLaser");
        }
    }
    public void BuyKatana(GameObject player)
    {
        
        if (buyPrice < exp && katanaUpgrades > 0)
        {
            if (hasKatana)
            {
                //upgrade katana
                player.gameObject.SendMessage("increaseKatanaTimeToLive", 0.15);
                katanaUpgrades--;
                buyPrice += 5;
            }
            else
            {
                player.gameObject.SendMessage("SetKatana", true);
                hasKatana = true;
            }
            exp -= buyPrice;
            print("BuyKatana");
        }
    }
    public void BuyTaser(GameObject player)
    {
        
        if (buyPrice < exp && taserUpgrades > 0)
        {
            if (hasTaser)
            {
                //upgrade taser
                player.gameObject.SendMessage("increaseTaserTimeToLive", 0.1);
                player.gameObject.SendMessage("increaseTaserCDTime", 0.1);
                taserUpgrades--;
                buyPrice += 5;
            }
            else
            {
                player.gameObject.SendMessage("SetTaser", true);
                hasTaser = true;
            }
            exp -= buyPrice;
            print("BuyTaser");
        }
    }
    public void BuyKnife(GameObject player)
    {
        
        if (buyPrice < exp && knifeUpgrades > 0)
        {
            if (hasKnife)
            {
                //upgrade knife
                player.gameObject.SendMessage("increaseKnifeCDTime", -0.12);
                knifeUpgrades--;
                buyPrice += 5;
            }
            else
            {
                player.gameObject.SendMessage("SetKnife", true);
                hasKnife = true;
            }
            exp -= buyPrice;
            print("BuyKnife");
        }
    }
    public void BuyDuration(GameObject player)
    {
        if (buyPrice < exp && DurationUpgrades > 0)
        {
            player.gameObject.SendMessage("increaseTaserTimeToLive", 0.1);
            player.gameObject.SendMessage("increaseTaserCDTime", 0.1);
            player.gameObject.SendMessage("increaseKatanaTimeToLive", 0.1);
            player.gameObject.SendMessage("increaseKatanaCDTime", 0.1);
            exp -= buyPrice;
            DurationUpgrades--;
            print("BuyDuration");
        }
    }
    public void BuySpeed(GameObject player)
    {
        if (buyPrice < exp && SpeedUpgrades > 0)
        {
            player.gameObject.SendMessage("IncreaseSpeed", 0.3);
            exp -= buyPrice;
            SpeedUpgrades--;
            print("BuySpeed");
        }
    }
    public void BuyProjSpeed(GameObject player)
    {
        if (buyPrice < exp && ProjSpeedUpgrades > 0)
        {
            player.gameObject.SendMessage("increaseKnifeSpeed", 20);
            player.gameObject.SendMessage("increaseLaserSpeed", 20);
            exp -= buyPrice;
            ProjSpeedUpgrades--;
            print("BuyProjSpeed");
        }
    }
    public void BuyDamage(GameObject player)
    {
        if (buyPrice < exp && DamageUpgrades > 0)
        {
            player.gameObject.SendMessage("increaseKnifeDamage", 2);
            player.gameObject.SendMessage("increaseTaserDamage", 2);
            player.gameObject.SendMessage("increaseLaserDamage", 2);
            player.gameObject.SendMessage("increaseKatanaDamage", 2);
            exp -= buyPrice;
            DamageUpgrades--;
            print("BuyDamage");
        }
    }
}