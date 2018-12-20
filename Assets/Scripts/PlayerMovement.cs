using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed;

    float horizontalMove = 0f;
    bool jump = false;

    public bool reachedWalker = false;

    public bool handedApplication = false;

    public bool gamePaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gamePaused)
        {
            if (!reachedWalker)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                animator.SetBool("IsMoving", horizontalMove != 0);

                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    Debug.Log("Jumping");
                }
            }
            else
            {
                StartCoroutine(RegisterOnAnimationEnd());
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void walkerReached()
    {
        animator.SetTrigger("ReachedWalker");
        horizontalMove = 0;
        reachedWalker = true;
        animator.SetBool("HandedApplication", true);
    }

    private IEnumerator RegisterOnAnimationEnd()
    {
        yield return new WaitForSeconds(1.2f);
        handedApplication = true;
    }
}
