using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private bool grounded; //Is the player on the ground
    private Rigidbody2D rb; //The RB of the GO
    public float jumpForce; //The power the player has on their jump


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a") && grounded == true)
        {

        }
    }
}
