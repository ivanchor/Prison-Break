using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH SCRIPT TO PLAYER OBJECT
public class KnifeArmScript : MonoBehaviour
{
    public GameObject knife;
    public float TimeToLive = 2f;
    private GameObject knifeinstat;
    public float cooldownTime = 3f;
    int counter = 0;
    public float launchVelocity = 50f;
    private float spawnDistance = 0.3f;
    private float nextActionTime = 0.0f;
    public bool hasKnife = true;
    public bool hasUltimate = false;
    public float knifeDamage = 20;
    public float knifeRange = 0.15f;
    // Start is called before the first frame update

    void Start()
    {
        //GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (Time.time > nextActionTime && hasKnife == true)
        {
            nextActionTime = cooldownTime + Time.time;
            if (hasUltimate == true)
            {
                ThrowUltimateKnives();
                //sends current damage and range to the newly created knife object
                knifeinstat.gameObject.SendMessage("recieveKnife", knifeDamage);
                knifeinstat.gameObject.SendMessage("recieveKnifeRange", knifeRange);
            }
            else
            {
                ThrowKnives();
                //sends current damage and range to the newly created knife object
                knifeinstat.gameObject.SendMessage("recieveKnife", knifeDamage);
                knifeinstat.gameObject.SendMessage("recieveKnifeRange", knifeRange);
            }        
        }
    }
    void ThrowKnives()
    {
        switch (counter) //creates a knife object and launches it in one of 8 directions in order
        {
            case 0:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y + 0f, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -90f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
                counter++;
                break;
            case 1:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -45f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, launchVelocity, 0));
                counter++;
                break;
            case 2:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + 0f, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 0f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
                counter++;
                break;
            case 3:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 45f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, launchVelocity, 0));
                counter++;
                break;
            case 4:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y + 0f, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 90f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, 0, 0));
                counter++;
                break;
            case 5:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 135f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, -launchVelocity, 0));
                counter++;
                break;
            case 6:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + 0f, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 180f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, -launchVelocity, 0));
                counter++;
                break;
            case 7:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -135f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, -launchVelocity, 0));
                counter = 0;
                break;
        }
        Destroy(knifeinstat, TimeToLive);
    }
    void ThrowUltimateKnives()
    {
        switch (counter)
        {
            case 0:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y + 0f, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -90f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + 0f, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 0f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y + 0f, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 90f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, 0, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + 0f, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 180f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, -launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                counter++;
                break;
            default:
                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -45f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y + spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 45f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x - spawnDistance, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, 135f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-launchVelocity, -launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                knifeinstat = Instantiate(knife, new Vector3(transform.position.x + spawnDistance, transform.position.y - spawnDistance, transform.position.z + 0f), Quaternion.Euler(0f, 0f, 0f));
                knifeinstat.transform.Rotate(0f, 0f, -135f, Space.Self);
                knifeinstat.transform.parent = gameObject.transform;
                knifeinstat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, -launchVelocity, 0));
                Destroy(knifeinstat, TimeToLive);

                counter = 0;
                break;
        }
        
    }
    public void SetKnife(bool knifaBool)
    {
        hasKnife = knifaBool;
    }
    public void SetKnifeUltimate(bool ultimateBool)
    {
        hasUltimate = ultimateBool;
    }
    public void increaseKnifeCDTime(float cdTime)
    {
        cooldownTime += cdTime;
    }
    public void increaseKnifeDamage(float newDamage)
    {
        knifeDamage += newDamage;
    }
    public void increaseKnifeSpeed(float newSpeed)
    {
        launchVelocity += newSpeed;
    }

    public void increaseKnifeRange(float newRange)
    {
        knifeRange += newRange;
    }

    public void increaseKnifeTimeToLive(float newTime)
    {
        TimeToLive += newTime;
    }
}

