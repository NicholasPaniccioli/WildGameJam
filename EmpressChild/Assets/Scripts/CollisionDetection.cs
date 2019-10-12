using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //Fields
    //Dimensions For Collision
    public static float minY;
    public static float minX;
    public static float maxY;
    public static float maxX;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        //Starts getting the bounds of the GO
        collider = GetComponent<BoxCollider2D>();
        minY = collider.bounds.min.y;
        minX = collider.bounds.min.x;
        maxY = collider.bounds.max.y;
        maxX = collider.bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps updating the bounds
        minY = collider.bounds.min.y;
        minX = collider.bounds.min.x;
        maxY = collider.bounds.max.y;
        maxX = collider.bounds.max.x;
    }
}
