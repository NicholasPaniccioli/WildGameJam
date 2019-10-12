using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;

   // public Vector3 camPos; // Position of the camera
    //public GameObject cam; //The camera

    // Start is called before the first frame update
    void Start()
    {
        //starts the camera looking at the player
        //camPos.x = player.transform.position.x;
        //camPos.y = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);

        this.transform.position = position;
    }
}
