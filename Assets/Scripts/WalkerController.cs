using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement applicantController = other.GetComponent<PlayerMovement>();
        if (applicantController)
        {
            if (other.gameObject.transform.position.x < this.gameObject.transform.position.x)
            {
                if (transform.localScale.x < 0)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
            else
            {
                if (transform.localScale.x > 0)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
            applicantController.walkerReached();
            animator.SetTrigger("ReachedWalker");
        }
    }


}
