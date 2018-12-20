using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBaseController : MonoBehaviour {

    public GameObject leftEndpoint;
    public GameObject rightEndpoint;
    public float speed;
    public bool movingRight = true;

    public bool frozen = false;

    private GameObject target = null;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (!frozen)
        {
            if (this.gameObject.transform.position.x + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2 >= rightEndpoint.transform.position.x && movingRight)
            {
                movingRight = false;
            }
            else if (this.gameObject.transform.position.x - this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2 <= leftEndpoint.transform.position.x && !movingRight)
            {
                movingRight = true;
            }
            else
            {
                Vector3 changeX = new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                if (movingRight)
                {
                    this.gameObject.transform.position += changeX;
                    if (target != null)
                    {
                        target.transform.position += changeX;
                    }
                }
                else
                {
                    this.gameObject.transform.position -= changeX;
                    if (target != null)
                    {
                        target.transform.position -= changeX;
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            target = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            target = null;
        }
    }

}
