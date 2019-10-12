using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlatformValues : MonoBehaviour
{
    //how many tiles wide the middle is
    public int middleWidth;
    private int currentWidth;
    private bool currentHorizontal = false;
    public GameObject middlePrefab;
    public GameObject leftEnd;
    public GameObject rightEnd;
    private List<GameObject> middleBlocks = new List<GameObject>();
    private BoxCollider2D boxcollider;

    public bool horizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        boxcollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying && (currentWidth != middleWidth || currentHorizontal != horizontal))
        {
            currentWidth = middleWidth;
            currentHorizontal = horizontal;

            while (transform.childCount > 2)
            {
                DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);
            }

            middleBlocks = new List<GameObject>();

            float midWorldWidth = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            float midWorldHeight = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

            if (horizontal)
            {
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 1.5f, 0, 0) + transform.position;

                // Scale
                midWorldWidth *= transform.localScale.x;

                // Loop to add middle platforms
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 1.5f + (midWorldWidth * midCount), 0, 0) + transform.position;
                }

                // Translate the right platform to the end
                rightEnd.transform.Translate(new Vector3(midWorldWidth * (middleWidth), 0, 0));

                boxcollider.size = new Vector2(midWorldWidth*(middleWidth+2), 1);
                boxcollider.offset = new Vector2(boxcollider.size.x / 2, 0);
            }

            else
            {
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 0.5f, rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y * 1f, 0) + transform.position;

                // Scale
                midWorldHeight *= transform.localScale.y;

                // Loop to add middle platforms
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 0.5f, midWorldWidth * 1f + (midWorldWidth * midCount), 0) + transform.position;
                }

                // Translate the right platform to the end
                rightEnd.transform.Translate(new Vector3(0, midWorldWidth * (middleWidth), 0));

                boxcollider.size = new Vector2(1 , midWorldWidth * (middleWidth + 2));
                boxcollider.offset = new Vector2(0.5f , (boxcollider.size.y -1)/ 2);
            }
        }
    }
}
