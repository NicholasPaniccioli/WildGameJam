using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Protagonist").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(pm.climbing)
            {
                pm.EndClimb();
            }
            pm.canClimb = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pm.canClimb = true;
        }
    }
}
