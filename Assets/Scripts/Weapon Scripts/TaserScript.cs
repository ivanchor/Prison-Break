using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH SCRIPT TO PLAYER OBJECT
public class TaserScript : MonoBehaviour
{
    public GameObject taserField;
    public float TimeToLive = 1f;
    private GameObject taserinstat;
    public float cooldownTime = 3f;
    private float nextActionTime = 0.0f;
    public bool hasTaser = true;
    public bool hasUltimate = false;
    public float taserDamage = 4;
    public float taserRange = 0.3f;
    // Start is called before the first frame update

    void Start()
    {
        //GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (Time.time > nextActionTime && hasTaser == true)
        {
            nextActionTime = cooldownTime + Time.time;
            if (hasUltimate == true)
            {
                Taze(); //change to add an ultimate version
                //sends current damage and range to the newly created taserfield object
                taserinstat.gameObject.SendMessage("recieveTaser", taserDamage);
                taserinstat.gameObject.SendMessage("recieveTaserRange", taserRange);
            }
            else
            {
                Taze();
                //sends current damage and range to the newly created taserfield object
                taserinstat.gameObject.SendMessage("recieveTaser", taserDamage);
                taserinstat.gameObject.SendMessage("recieveTaserRange", taserRange);
            }
            
        }
        
    }
    void Taze()
    {
        taserinstat = Instantiate(taserField, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        taserinstat.transform.parent = gameObject.transform;
        Destroy(taserinstat, TimeToLive);
    }
    public void SetTaser(bool taserBool)
    {
        hasTaser = taserBool;
    }
    public void SetTaserUltimate(bool ultimateBool)
    {
        hasUltimate = ultimateBool;
    }
    public void increaseTaserCDTime(float cdTime)
    {
        cooldownTime += cdTime;
    }
    public void increaseTaserDamage(float newDamage)
    {
        taserDamage += newDamage;
    }
    public void increaseTaserRange(float newRange)
    {
        taserRange += newRange;
    }
    public void increaseTaserTimeToLive(float newTime)
    {
        TimeToLive += newTime;
    }
}
