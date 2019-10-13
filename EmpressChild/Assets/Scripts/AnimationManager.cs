using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovementScript;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerMovementScript.playerState)
        {
            case PlayerMovement.PlayerState.Running:
                animator.SetBool("Running", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Jumping", false);
                break;

            case PlayerMovement.PlayerState.Jumping:
                animator.SetBool("Jumping", true);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Climbing", false);
                break;

            case PlayerMovement.PlayerState.Falling:
                animator.SetBool("Falling", true);
                animator.SetBool("Jumping", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Climbing", false);
                break;

            case PlayerMovement.PlayerState.Climbing:
                animator.SetBool("Climbing", true);
                animator.SetBool("Jumping", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Running", false);
                animator.SetBool("Falling", false);
                break;

            case PlayerMovement.PlayerState.Idle:
                animator.SetBool("Idle", true);
                animator.SetBool("Running", false);
                animator.SetBool("Falling", false);
                animator.SetBool("Climbing", false);
                break;
        }
    }
}
