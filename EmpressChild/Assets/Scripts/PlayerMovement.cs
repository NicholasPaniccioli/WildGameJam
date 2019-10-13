using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum FacingDirection { Left, Right }
    //Fields

    //Attributes
    public float jumpForce; //The power the player has on their jump
    public float climbSpeed = 2.5f; //How fast the player is able to climb
    public Vector3 jumpVec; //Vector for the jumpforce to be applied to
    public float speed = 40f;
    public float maxVelocityX = 3f;
    public FacingDirection facingDirection = FacingDirection.Right;

    //Components
    private Rigidbody2D rb; //The RB of the GO
    private BoxCollider2D pCollider;
    private CanSpawnTrees treeSpawn;

    //Flags
    public bool grounded; //Is the player on the ground
    public bool canClimb; //Is the player on touching a vine?
    public bool climbing; //Is the player climbing?

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 4.0f;
        jumpVec = new Vector3(0.0f, 6.0f, 0.0f);

        pCollider = GetComponent<BoxCollider2D>();
        treeSpawn = GetComponent<CanSpawnTrees>();
    }

    // Update is called once per frame
    void Update()
    {

        //Checking for Key inputs
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) //JUMP
        {
            if (grounded && !canClimb)
            {
                rb.AddForce(jumpVec * jumpForce, ForceMode2D.Impulse);
                grounded = false; //Since they jumped they are no longer grounded
            }
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (canClimb && !climbing)
            {
                rb.gravityScale = 0f;
                //pRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                climbing = true;
                rb.velocity = new Vector2();
            }
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.AddForce(new Vector3(input.x * speed, 0f, 0f), ForceMode2D.Force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocityX, maxVelocityX), rb.velocity.y); 

        if(Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.KeypadEnter))
        {
            treeSpawn.SpawnTree();
        }

        if(climbing)
        {
            rb.velocity = new Vector2();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(0, climbSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-climbSpeed * Time.deltaTime/ 3 * 2, 0));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
            {
                transform.Translate(new Vector2(climbSpeed * Time.deltaTime / 3 * 2, 0));
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                EndClimb();
            }
        }
        if(Mathf.Abs(rb.velocity.x) > .025)
        facingDirection = rb.velocity.x > 0 ? FacingDirection.Right : FacingDirection.Left;
        transform.localScale = facingDirection == FacingDirection.Right ? new Vector3(.15f, .15f, 1f) : new Vector3(-.15f, .15f, 1f);
        

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
        print("min pcollider: " + pCollider.bounds.min.y + " max collider: " + collision.collider.bounds.max.y);
        if(collision.gameObject.tag == "Platform" && 
            pCollider.bounds.min.y >= collision.collider.bounds.max.y - .05f)
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
