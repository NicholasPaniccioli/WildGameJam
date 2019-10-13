 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlatformValues : MonoBehaviour
{
    //how many tiles wide the middle is
    public int middleWidth;
    public GameObject middlePrefab;
    //refrences to both end pieces
    public GameObject leftEnd;
    public GameObject rightEnd;
    public bool horizontal = true;

    //holds all middle blocks
    private List<GameObject> middleBlocks = new List<GameObject>();
    //holds the platform's boxcollider
    private BoxCollider2D boxcollider;

    //track if the editor should update middle clones
    private int currentWidth;
    private bool currentHorizontal = false;

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

            while (transform.childCount > 3)
            {
                DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);
            }

            middleBlocks = new List<GameObject>();

            float midWorldWidth = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x -0.01f;
            float midWorldHeight = middlePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y - 0.01f;

            if (horizontal)
            {
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 1.4f, 0, 0) + transform.position;
                leftEnd.transform.rotation = Quaternion.Euler(0, 0, 0);
                rightEnd.transform.rotation = Quaternion.Euler(0, 0, 0);
                // Scale
                midWorldWidth *= transform.localScale.x;
                midWorldHeight *= transform.localScale.y;

                // Loop to add middle platforms
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 1.5f + (midWorldWidth * midCount), 0, 0) + transform.position;
                    middleBlocks[midCount].transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                // Translate the right platform to the end
                rightEnd.transform.Translate(new Vector3(midWorldWidth * (middleWidth), 0, 0));


                midWorldWidth /= transform.localScale.x;
                midWorldHeight /= transform.localScale.y;
                boxcollider.size = new Vector2(midWorldWidth*(middleWidth+2), midWorldHeight*.7f);
                boxcollider.offset = new Vector2(boxcollider.size.x / 2, 0);
            }

            else
            {
                rightEnd.transform.position = new Vector3(rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x * 0.5f, rightEnd.GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y * .8f, 0) + transform.position;

                // Scale
                midWorldHeight *= transform.localScale.y;

                // Loop to add middle platforms
                for (int midCount = 0; midCount < middleWidth; midCount++)
                {
                    middleBlocks.Add(Instantiate(middlePrefab, transform));
                    middleBlocks[midCount].transform.position = new Vector3(midWorldWidth * 0.5f, midWorldWidth * 1f + (midWorldWidth * midCount), 0) + transform.position;
                    middleBlocks[midCount].transform.rotation = Quaternion.Euler(0, 0, 90);
                }

                // Translate the right platform to the end
                rightEnd.transform.Translate(new Vector3(0, midWorldWidth * (middleWidth), 0));
                leftEnd.transform.rotation = Quaternion.Euler(0, 0, 90);
                rightEnd.transform.rotation = Quaternion.Euler(0, 0, 90);

                midWorldWidth /= transform.localScale.x;
                midWorldHeight /= transform.localScale.y;
                boxcollider.size = new Vector2(midWorldHeight * .7f, midWorldWidth * (middleWidth + 2));
                boxcollider.offset = new Vector2(midWorldHeight/2 , (boxcollider.size.y -4)/ 2);
            }
        }
    }
}
