using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields

    private Rigidbody2D rb; //The RB of the GO
    public float jumpForce; //The power the player has on their jump
    public Vector3 jumpVec; //Vector for the jumpforce to be applied to
    public bool grounded; //Is the player on the ground


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
        if (Input.GetKeyDown(KeyCode.W) && grounded == true) //JUMP
        {
            rb.AddForce(jumpVec * jumpForce, ForceMode2D.Impulse);
            grounded = false; //Since they jumped they are no longer grounded
        }
        if(Input.GetKey(KeyCode.A)) //LEFT
        {
            rb.AddForce(new Vector3(-2.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.D)) //RIGHT
        {
            rb.AddForce(new Vector3(2.0f, 0.0f, 0.0f) * 20, ForceMode2D.Force);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided!" + collision.gameObject.tag);
        print((pCollider.transform.position.y + pCollider.size.y).ToString() + collision.transform.position.y);
        //check to see if the collider is a platfrom, and make sure it didn't collide with the side of the platfrom
        if(collision.gameObject.tag == "Platform" && 
            pCollider.bounds.min.y >= collision.collider.bounds.max.y)
        {
            grounded = true;
        }
    }
}
