﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallax); 
        float temp = (cam.transform.position.x * (1 - parallax));
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);


       if(temp > startPos + length)
       {
           startPos += length;
       }
       else if(temp < startPos - length)
       {
           startPos -= length;
       }
    }
}
