using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomReceptionist : MonoBehaviour
{
    public Sprite[] receptionists;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void OnEnable()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SceneManager.sceneLoaded += RandomizeReceptionist;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomizeReceptionist(Scene scene, LoadSceneMode mode)
    {
        spriteRenderer.sprite = receptionists[Random.Range(0, receptionists.Length)];
        print("Working");
    }
}
