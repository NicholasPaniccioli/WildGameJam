using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomReceptionist : MonoBehaviour
{
    public Sprite[] receptionists;
    public SpriteRenderer spriteRenderer;
    public GameObject receptionist;

    // Start is called before the first frame update
    void OnEnable()
    {
        spriteRenderer = receptionist.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        RandomizeReceptionist();
    }
    private void RandomizeReceptionist()
    {
        spriteRenderer.sprite = receptionists[Random.Range(0, receptionists.Length)];
        print("Working");
    }
}
