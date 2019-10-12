﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlatformValues : MonoBehaviour
{
    //how many tiles wide the middle is
    public int middleWidth;
    private int currentWidth;
    public GameObject middlePrefab;
    public GameObject leftEnd;
    public GameObject rightEnd;
    private List<GameObject> middleBlocks = new List<GameObject>();

    public bool horizontal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying && currentWidth != middleWidth)
        {
            if (horizontal)
            {
                currentWidth = middleWidth;
                foreach (GameObject t in middleBlocks)
                {
                    DestroyImmediate(t);
                }
                middleBlocks = new List<GameObject>();
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 1.5f, 0, 0) + transform.position;
                float midWorldWidth = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
                float midWorldHeight = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 1.5f + (midWorldWidth * midCount), 0, 0) + transform.position;
                }
                rightEnd.transform.Translate(new Vector3(midWorldWidth * (middleWidth), 0, 0));
            }

            else
            {
                currentWidth = middleWidth;
                foreach (GameObject t in middleBlocks)
                {
                    DestroyImmediate(t);
                }
                middleBlocks = new List<GameObject>();
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 0.5f, rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y * 1f, 0) + transform.position;
                float midWorldWidth = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
                float midWorldHeight = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 0.5f, midWorldWidth * 1f + (midWorldWidth * midCount), 0) + transform.position;
                }
                rightEnd.transform.Translate(new Vector3(0, midWorldWidth * (middleWidth), 0));
            }
        }
    }
}
