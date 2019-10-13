using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    private PlayerMovement pm;
    private GameObject spriteMask;
    private Vector3 velocity;
    public float growTime;
    public float heightPercent;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Protagonist").GetComponent<PlayerMovement>();
        spriteMask = transform.GetChild(0).gameObject;
        growTime = heightPercent * 5;
        velocity = new Vector3(0, gameObject.GetComponent<SpriteRenderer>().bounds.size.y * heightPercent / growTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(growTime>0)
        {
            float dTime = Time.deltaTime;
            growTime -= dTime;
            transform.Translate(velocity * dTime);
            spriteMask.transform.Translate(-1 * velocity * dTime);
            if(growTime <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
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
