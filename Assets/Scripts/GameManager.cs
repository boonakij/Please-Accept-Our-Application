using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float timeLeft;
    public GameObject countdownText;
    public GameObject successScreen;
    public GameObject failureScreen;

    public GameObject Boon;
    public GameObject Emily;

    public bool gameOver;

    bool gamePaused;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (!gamePaused)
        {
            if (Boon.GetComponent<PlayerMovement>().handedApplication)
            {
                GameObject.Find("Boon").transform.localScale = new Vector3(0, 0, 0);
            }

            if (Emily.GetComponent<PlayerMovement>().handedApplication)
            {
                GameObject.Find("Emily").transform.localScale = new Vector3(0, 0, 0);
            }

            if (Boon.GetComponent<PlayerMovement>().handedApplication && Emily.GetComponent<PlayerMovement>().handedApplication)
            {
                //PauseGame();
                successScreen.SetActive(true);
            }
            else
            {
                if (timeLeft > 0 && !gameOver)
                {
                    timeLeft -= Time.deltaTime;
                    int roundedTime = (int)timeLeft;
                    countdownText.GetComponent<Text>().text = "Application due in: " + "\n" + roundedTime;
                }
                else
                {
                    //PauseGame();
                    GameOver();
                }

            }
        }

    }

    public void PauseGame()
    {
        //Time.timeScale = 0;
        gamePaused = true;
        Boon.GetComponent<PlayerMovement>().gamePaused = true;
        Emily.GetComponent<PlayerMovement>().gamePaused = true;
    }

    public void ContinueGame()
    {
        //Time.timeScale = 1;
        gamePaused = false;
        Boon.GetComponent<PlayerMovement>().gamePaused = false;
        Emily.GetComponent<PlayerMovement>().gamePaused = false;
    }

    public void GameOver()
    {
        gameOver = true;
        failureScreen.SetActive(true);
    }


}
