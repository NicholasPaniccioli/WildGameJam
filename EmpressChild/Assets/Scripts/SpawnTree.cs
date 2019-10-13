using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    private bool hasTree = false;
    private CanSpawnTrees interacter; //the class that will interact with this tree spawner
    public GameObject tree; //holds a prefab of the tree that should be spawned
    public float treeHight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            GameObject vine = Instantiate(tree, transform.position + new Vector3(0, -tree.GetComponent<SpriteRenderer>().bounds.extents.y, 0), Quaternion.identity);
            //    vine.GetComponent<Vine>().growTime = treeHight / 2;
            //    ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
            //    var main = ps.main;
            //    main.duration = treeHight / 2f;
        }
    }
}

