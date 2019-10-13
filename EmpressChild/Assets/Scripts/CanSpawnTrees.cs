using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSpawnTrees : MonoBehaviour
{
    public SpawnTree treeSpawner; //Holds a reference to the tree spawner that is being interacted with, set by the tree spawner

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTree()
    {
        if(treeSpawner != null)
        {
            treeSpawner.Activate();
        }
    }
}
