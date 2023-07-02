using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Object to follow
    public Transform targetDestination;
    
    // Enemy stats
    public float speed;
    public int hp = 100;
 

    bool facingRight = true;
    public HudManager hud;

    GameObject targetGameobject;


    Rigidbody2D rgdbd2d;

    // Start is called before the first frame update
    void Start()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        //movementVector =
        targetGameobject = targetDestination.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
        //Debug.Log(rgdbd2d.velocity);
        if(rgdbd2d.velocity.x > 0 && facingRight)
        {
            Flip();
            //Debug.Log("Enemy is Moving Right");
        }
        if(rgdbd2d.velocity.x < 0 && !facingRight)
        {
            Flip();
            //Debug.Log("Enemy is Moving Left");
        }
    }

    // Flips the sprite to face the other direction. Facing left -> facing right
    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp < 1)
        {
            GameManager.instance.IncreaseScore(1);
            GameManager.instance.IncreaseExp(10);
            hud.Refresh();
            Destroy(gameObject);
        }
    }

}
