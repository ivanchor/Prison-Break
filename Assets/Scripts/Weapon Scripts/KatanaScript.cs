using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH SCRIPT TO PLAYER OBJECT
public class KatanaScript : MonoBehaviour
{
    public GameObject katana;
    public float TimeToLive = 0.5f;
    public bool hasKatana = true;
    public bool hasUltimate = false;
    private GameObject bladeinstat;
    public float speed = 200f;
    public float cooldownTime = 3f;
    private float spawnDistance = 0.4f;
    private Vector3 axis = new Vector3(0, 0, 1); //z axis inorder for the katana to rotate around
    private Vector3 axis2 = new Vector3(0, 0, 0); //saved location of the layer when the katana object is first created
    private float nextActionTime = 0.0f;
    public float katanaDamage = 20f;
    public float katanaRange = 0.2f;
    private string moveDir;
    // Start is called before the first frame update

    void Start()
    {
        //GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (Time.time > nextActionTime && hasKatana == true)
        {
            nextActionTime = cooldownTime + Time.time;
            switch (moveDir)
            {
                case ("down"):
                    SwingKatanaDown();
                    break;
                case ("right"):
                    SwingKatanaRight();
                    break;
                case ("left"):
                    SwingKatanaLeft();
                    break;
                case ("upright"):
                    SwingKatanaUpRight();
                    break;
                case ("upleft"):
                    SwingKatanaUpLeft();
                    break;
                case ("downright"):
                    SwingKatanaDownRight();
                    break;
                case ("downleft"):
                    SwingKatanaDownLeft();
                    break;
                default:
                    SwingKatanaUp();
                    break;
            }
            //sends current damage and range to the newly created katana object
            bladeinstat.gameObject.SendMessage("recieveKatana", katanaDamage); 
            bladeinstat.gameObject.SendMessage("recieveKatanaRange", katanaRange);
        }
        if (bladeinstat)
        {
           bladeinstat.transform.RotateAround(axis2, axis, speed * Time.deltaTime);
        }
        
    }
    void SwingKatanaUp() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x + spawnDistance, axis2.y + spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, -45f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaRight() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x + spawnDistance, axis2.y - spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, -135f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaLeft() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x - spawnDistance, axis2.y + spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, 45f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaDown()
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x - spawnDistance, axis2.y - spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, 135f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaUpRight() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x + 2* spawnDistance, axis2.y, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, -90f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }   
    void SwingKatanaUpLeft() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x, axis2.y + 2*spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, 0f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaDownRight() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x, axis2.y - 2*spawnDistance, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, 180f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    void SwingKatanaDownLeft() 
    {
        axis2 = transform.position;
        bladeinstat = Instantiate(katana, new Vector3(axis2.x - 2*spawnDistance, axis2.y, axis2.z), Quaternion.Euler(0f, 0f, 0f));
        bladeinstat.transform.Rotate(0f, 0f, 90f, Space.World);
        bladeinstat.transform.parent = gameObject.transform;
        Destroy(bladeinstat, TimeToLive);
    }
    public void SetKatana(bool katanBool)
    {
        hasKatana = katanBool;
    }
    public void SetKatanaUltimate(bool ultimateBool)
    {
        hasUltimate = ultimateBool;
    }
    public void increaseKatanaCDTime(float cdTime)
    {
        cooldownTime += cdTime;
    }
    public void increaseKatanaSpeed(float newSpeed)
    {
        speed += newSpeed;
    }
    public void increaseKatanaDamage(float newDamage)
    {
        katanaDamage += newDamage;
    }
    public void increaseKatanaRange(float newRange)
    {
        katanaRange += newRange;
    }
    public void increaseKatanaTimeToLive(float newTime)
    {
        TimeToLive += newTime;
    }
    public void RecieveMovement(string direc)
    {
        moveDir = direc;
    }
}
