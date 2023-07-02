using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH SCRIPT TO PLAYER OBJECT
public class LaserGunScript : MonoBehaviour
{
    public GameObject LaserBullet;
    public float TimeToLive = 1f;
    private GameObject laserInstat;
    public float cooldownTime = 0.5f;
    private float xSpeed;
    private float ySpeed;
    public float launchVelocity = 90f;
    private float nextActionTime = 0.0f;
    public bool hasLaser = true;
    public bool hasUltimate = true;
    public float laserDamage = 10;
    public float laserRange = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && hasLaser == true)
        {
            nextActionTime = cooldownTime + Time.time;
            if (hasUltimate == true)
            {
                FireUltimateLaser();
                //sends current damage and range to the newly created laser object
                laserInstat.gameObject.SendMessage("recieveLaser", laserDamage);
                laserInstat.gameObject.SendMessage("recieveLaserRange", laserRange);
            }
            else
            {
                FireLaser();
                //sends current damage and range to the newly created laser object
                laserInstat.gameObject.SendMessage("recieveLaser", laserDamage);
                laserInstat.gameObject.SendMessage("recieveLaserRange", laserRange);
            }
        }
        
    }
    void FireLaser()
    {
        //generates a random x velocity where x+y = the launchVelocity
        xSpeed = Random.Range(-launchVelocity, launchVelocity);
        ySpeed = launchVelocity - Mathf.Abs(xSpeed);
        int rand = Random.Range(0, 2);
        if (rand == 1) //randomly changes the y speed to be negative or positive
        {
            ySpeed = -1 * ySpeed;
        }
        laserInstat = Instantiate(LaserBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        laserInstat.transform.parent = gameObject.transform;
        laserInstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(xSpeed, ySpeed));
        Destroy(laserInstat, TimeToLive);
    }
    void FireUltimateLaser()
    {
        xSpeed = Random.Range(-launchVelocity, launchVelocity);
        ySpeed = launchVelocity - Mathf.Abs(xSpeed);
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            ySpeed = -1 * ySpeed;
        }
        // fires a laser object in the direction of the randomly generated x and y 
        laserInstat = Instantiate(LaserBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        laserInstat.transform.parent = gameObject.transform;
        laserInstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(xSpeed, ySpeed));
        Destroy(laserInstat, TimeToLive);
        // fires a second laser in the opposite direction of the first
        laserInstat = Instantiate(LaserBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        laserInstat.transform.parent = gameObject.transform;
        laserInstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-xSpeed, -ySpeed));
        Destroy(laserInstat, TimeToLive);
    }
    public void SetLaser(bool laserBool)
    {
        hasLaser = laserBool;
    }
    public void SetLaserUltimate(bool ultimateBool)
    {
        hasUltimate = ultimateBool;
    }
    public void increaseLaserCDTime(float cdTime)
    {
        cooldownTime += cdTime;
    }
    public void increaseLaserDamage(float newDamage)
    {
        laserDamage += newDamage;
    }
    public void increaseLaserSpeed(float newSpeed)
    {
        launchVelocity += newSpeed;
    }
    public void increaseLaserRange(float newRange)
    {
        laserRange += newRange;
    }
    public void increaseLaserTimeToLive(float newTime)
    {
        TimeToLive += newTime;
    }
}
