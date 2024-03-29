﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        //Just updates the player x
        //Camera only follows side to side
        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        this.transform.position = position;
    }
}
