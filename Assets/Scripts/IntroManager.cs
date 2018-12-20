using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public GameManager gm;

    public GameObject[] slides;

    public GameObject introScreen;

    public float[] slideTimes;

    int slideIndex = 0;

    float slideTimer;


	// Use this for initialization
	void Start () {
        gm.PauseGame();
        slideTimer = slideTimes[0];
	}

    // Update is called once per frame
    void Update() {
        if (slideIndex < slides.Length)
        {
            slideTimer -= Time.deltaTime;

            if (slideTimer < 0)
            {
                slideIndex += 1;
                slides[slideIndex].SetActive(true);
                slideTimer = slideTimes[slideIndex];
            }
        }
        else
        {
            introScreen.SetActive(false);
            gm.ContinueGame();
        }
    }
}
