using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields

    private Rigidbody2D rb; //The RB of the GO
    public float jumpForce; //The power the player has on their jump
    public float climbSpeed; //How fast the player is able to climb
    public Vector3 jumpVec; //Vector for the jumpforce to be applied to
    public bool grounded; //Is the player on the ground
    public bool canClimb; //Is the player on touching a vine?
    public bool climbing; //Is the player climbing?

    private BoxCollider2D pCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 7.0f;
        jumpVec = new Vector3(0.0f, 3.0f, 0.0f);

        pCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Checking for Key inputs
        if (Input.GetKeyDown(KeyCode.W)) //JUMP
        {
            if (canClimb)
            {
                rb.gravityScale = 0f;
                //pRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                climbing = true;
            }
            else if (grounded)
            {
                rb.AddForce(jumpVec * jumpForce, ForceMode2D.Impulse);
                grounded = false; //Since they jumped they are no longer grounded
            }
        }
        if(Input.GetKey(KeyCode.A)) //LEFT
        {
            rb.AddForce(new Vector3(-2.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.D)) //RIGHT
        {
            rb.AddForce(new Vector3(2.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
        }
        if(climbing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector2(0, climbSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector2(-climbSpeed * Time.deltaTime/ 3 * 2, 0));
            }
            if (Input.GetKey(KeyCode.D)) 
            {
                transform.Translate(new Vector2(climbSpeed * Time.deltaTime / 3 * 2, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                EndClimb();
            }
        }
    }

    public void EndClimb()
    {
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 3f;
        climbing = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check to see if the collider is a platfrom, and make sure it didn't collide with the side of the platfrom
        if(collision.gameObject.tag == "Platform" && 
            pCollider.bounds.min.y >= collision.collider.bounds.max.y)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" &&
            pCollider.bounds.min.y >= collision.collider.bounds.max.y)
        {
            grounded = false;
        }
        else if (collision.gameObject.tag == "Vine")
        {
            canClimb = false;
        }
    }
}
