using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields

    //For Collision and player values
    public static float minY;
    public static float minX;
    public static float maxY;
    public static float maxX;

    private Rigidbody2D rb; //The RB of the GO
    public float jumpForce; //The power the player has on their jump
    public Vector3 jumpVec; //Vector for the jumpforce to be applied to
    public bool grounded; //Is the player on the ground

    private Vector3 curPos;
    private Vector3 nextPos;

    private BoxCollider2D collider;
    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 3.0f;
        jumpVec = new Vector3(0.0f, 3.0f, 0.0f);
        curPos = transform.position;

        collider = GetComponent<BoxCollider2D>();
        minY = collider.bounds.min.y;
        minX = collider.bounds.min.x;
        maxY = collider.bounds.max.y;
        maxX = collider.bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        //continuously updates the colliders
        minY = collider.bounds.min.y;
        minX = collider.bounds.min.x;
        maxY = collider.bounds.max.y;
        maxX = collider.bounds.max.x;


        //checks if the player is on the ground
        if(minY - 0.001 < floor.GetComponent<BoxCollider2D>().bounds.max.y)
        {
            grounded = true;
        }

        //Checking for Key inputs
        if(Input.GetKeyDown(KeyCode.W) && grounded == true && minY > floor.GetComponent<BoxCollider2D>().bounds.max.y) //JUMP
        {
            rb.AddForce(jumpVec * jumpForce, ForceMode2D.Impulse);
            grounded = false; //Since they jumped they are no longer grounded
            nextPos.y = transform.position.y + 5.0f;
            curPos = nextPos;
        }
        if(Input.GetKey(KeyCode.A)) //LEFT
        {
            rb.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
            nextPos.x = transform.position.x - 1.0f;
            curPos = nextPos;
        }
        if(Input.GetKey(KeyCode.D)) //RIGHT
        {
            rb.AddForce(new Vector3(1.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
            nextPos.x = transform.position.x + 1.0f;
            curPos = nextPos;
        }
    }
}
