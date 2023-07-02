using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH SCRIPT TO WEAPON OBJECTs
public class ProjectileController : MonoBehaviour
{
    GameObject[] EnemyTag;
    private float TaserDamage = 0;
    private float KnifeDamage = 0;
    private float KatanaDamage = 0;
    private float LaserDamage = 0;
    private float TaserRange = 0;
    private float KnifeRange = 0;
    private float KatanaRange = 0;
    private float LaserRange = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckProjectiles();
    }
    public void CheckProjectiles() //checks to see if an enemy is in the appropriate distance away for the matching weapon object
    {
        EnemyTag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in EnemyTag)
        {
            if (Vector3.Distance(transform.position, go.transform.position) < TaserRange && gameObject.name == "TaserField(Clone)")
            {
                print("Taser damage" + TaserDamage);
                go.gameObject.SendMessage("TakeDamage", TaserDamage);
            }
            if (Vector3.Distance(transform.position, go.transform.position) < KnifeRange && gameObject.name == "ThrowingKnife(Clone)")
            {
                print("knife damage" + KnifeDamage);
                go.gameObject.SendMessage("TakeDamage", KnifeDamage);
            }
            if (Vector3.Distance(transform.position, go.transform.position) < KatanaRange && gameObject.name == "Katana(Clone)")
            {
                print("katana damage " + KatanaDamage);
                go.gameObject.SendMessage("TakeDamage", KatanaDamage);
            }
            if (Vector3.Distance(transform.position, go.transform.position) < LaserRange && gameObject.name == "LaserPistol(Clone)")
            {
                print("laser damage" + LaserDamage);
                go.gameObject.SendMessage("TakeDamage", LaserDamage);
            }
        }
    }
    public void recieveTaser(float damage)
    {
        TaserDamage = damage;
    }
    public void recieveKnife(float damage)
    {
        KnifeDamage = damage;
    }
    public void recieveKatana(float damage)
    {
        KatanaDamage = damage;
    }
    public void recieveLaser(float damage)
    {
        LaserDamage = damage;
    }
    public void recieveTaserRange(float range)
    {
        TaserRange = range;
    }
    public void recieveKnifeRange(float range)
    {
        KnifeRange = range;
    }
    public void recieveKatanaRange(float range)
    {
        KatanaRange = range;
    }
    public void recieveLaserRange(float range)
    {
        LaserRange = range;
    }
    
}
