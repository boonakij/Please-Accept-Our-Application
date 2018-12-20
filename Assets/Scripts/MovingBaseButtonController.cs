using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBaseButtonController : MonoBehaviour {

    public GameObject buttonUp;
    public GameObject buttonDown;

    public GameObject movingBase;

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
            buttonUp.SetActive(false);
            buttonDown.SetActive(true);
            movingBase.GetComponent<MovingBaseController>().frozen = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement applicantController = other.GetComponent<PlayerMovement>();
        if (applicantController)
        {
            buttonUp.SetActive(true);
            buttonDown.SetActive(false);
            movingBase.GetComponent<MovingBaseController>().frozen = true;
        }
    }
}
