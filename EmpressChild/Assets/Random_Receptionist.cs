using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Receptionist : MonoBehaviour
{
    public Sprite[] receptionistSprites;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        int rand = Random.Range(0, 6);

        sr.sprite = receptionistSprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
