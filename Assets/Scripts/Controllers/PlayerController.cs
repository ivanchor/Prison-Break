using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Sprite faceLeftSprite;
    public Sprite faceRightSprite;
    Rigidbody2D rgbd2d;
    Vector2 movementVector;
    float inputHorizontal;
    float inputVertical;
    bool facingRight = true;
    public HudManager hud;

    [SerializeField] float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        movementVector.x = inputHorizontal;
        movementVector.y = inputVertical;

        movementVector *= speed;

        rgbd2d.velocity = movementVector;

        if (inputHorizontal > 0 && !facingRight) 
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

        SendMovement();
    }

    //function flips sprite direction
    void Flip()
    {
        /* Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        */
        if (facingRight)
        {
            this.GetComponent<SpriteRenderer>().sprite = faceLeftSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = faceRightSprite;
        }

        facingRight = !facingRight;
    }
    
    /*
    Function: OnTriggerEnter2D
    Purpose: checks if the player has collided with certain triggers such as "enemy"
    */
    void OnTriggerEnter2D(Collider2D collider)
    {

        //Check if player collided with enemy
        if (collider.gameObject.tag == "Enemy")
        {
            //player is hit.
            print("Ouch!");
            GameManager.instance.DecreaseHealth(10);
            hud.Refresh();
            if (GameManager.instance.getHealth() <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

    }

    public void SendMovement()
    {
        string moveDirection = "";
        if (movementVector.x == 0 && movementVector.y == speed)
        {
            moveDirection = "up";
        }
        else if (movementVector.x == 0 && movementVector.y == -speed)
        {
            moveDirection = "down";
        }
        else if (movementVector.x == speed && movementVector.y == 0)
        {
            moveDirection = "right";
        }
        else if (movementVector.x == -speed && movementVector.y == 0)
        {
            moveDirection = "left";
        }
        else if (movementVector.x == speed && movementVector.y == speed)
        {
            moveDirection = "upright";
        }
        else if (movementVector.x == -speed && movementVector.y == speed)
        {
            moveDirection = "upleft";
        }
        else if (movementVector.x == speed && movementVector.y == -speed)
        {
            moveDirection = "downright";
        }
        else if (movementVector.x == -speed && movementVector.y == -speed)
        {
            moveDirection = "downleft";
        }
        gameObject.SendMessage("RecieveMovement", moveDirection);
    } 

    public void IncreaseSpeed(float newSpeed)
    {
        speed += newSpeed;
    }
}
