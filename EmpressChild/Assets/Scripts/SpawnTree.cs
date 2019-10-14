using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    private bool hasTree = false;
    private CanSpawnTrees interacter; //the class that will interact with this tree spawner
    public GameObject tree; //holds a prefab of the tree that should be spawned
    public float treeHight;
    private Vector3 velocity;
    public float growTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (growTime > 0)
        {
            float dTime = Time.deltaTime;
            growTime -= dTime;
            transform.Translate(velocity * dTime);
            if(growTime <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interacter != null && other.gameObject == interacter.gameObject)
        {
            interacter.treeSpawner = null;
            interacter = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasTree)
        {
            interacter = collision.gameObject.GetComponent<CanSpawnTrees>();
            interacter.treeSpawner = this;
        }
    }

    //if the tree spawner hasn't spawned a tree, then spawn a tree
    public void Activate()
    {
        if (!hasTree)
        {
            hasTree = true;
            GameObject vine = Instantiate(tree, transform.position + new Vector3(0, -tree.GetComponent<SpriteRenderer>().bounds.extents.y -.4f, 1), Quaternion.identity);
            if(gameObject.transform.parent.tag == "Moving Object")
            {
                vine.transform.parent = gameObject.transform.parent;

            }
            vine.GetComponent<Vine>().heightPercent = treeHight;
            growTime = .5f;
            velocity = new Vector3(0, -gameObject.GetComponent<SpriteRenderer>().bounds.size.y / growTime, 0);
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}

