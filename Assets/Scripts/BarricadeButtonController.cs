using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeButtonController : MonoBehaviour {

    public GameObject buttonUp;
    public GameObject buttonDown;
    public GameObject[] barricadesUp;
    public GameObject[] barricadesDown;

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
            foreach (GameObject barricadeUp in barricadesUp) {
                barricadeUp.SetActive(false);
            }
            foreach (GameObject barricadeDown in barricadesDown)
            {
                barricadeDown.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement applicantController = other.GetComponent<PlayerMovement>();
        if (applicantController)
        {
            buttonUp.SetActive(true);
            buttonDown.SetActive(false);
            foreach (GameObject barricadeUp in barricadesUp)
            {
                barricadeUp.SetActive(true);
            }
            foreach (GameObject barricadeDown in barricadesDown)
            {
                barricadeDown.SetActive(false);
            }
        }
    }
}
