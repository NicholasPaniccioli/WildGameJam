using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public GameObject platform;
    public Direction direction;

    public Vector3 velocity;
    public float moveDistance = 1f;
    public float moveTime = 1f;
    public bool moving = false;


    // Start is called before the first frame update
    void Start()
    {
        switch(direction)
        {
            case Direction.Left:
                velocity = new Vector3(-moveDistance / moveTime, 0, 0);
                break;
            case Direction.Right:
                velocity = new Vector3(moveDistance / moveTime, 0 , 0);
                break;
            case Direction.Up:
                velocity = new Vector3(0, moveDistance / moveTime, 0);
                break;
            case Direction.Down:
                velocity = new Vector3(0, -moveDistance / moveTime, 0);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moving && moveTime > 0)
        {
            float dTime = Time.deltaTime;
            moveTime -= dTime;
            platform.transform.Translate(velocity * dTime);
            
            if(moveTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
        }
    }
}
