using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecountdown : MonoBehaviour
{

    public GameObject GameDeathImage;

    private AvatarAnimationController animator;

    public float timeRemaining = 10;

    public bool timerIsRunning = false;

    public Text timeText;

    void Start()
    {
        timerIsRunning = true;

        animator = GetComponent<AvatarAnimationController>();


    }
    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeRemaining);

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // Play dead animation.
                animator.ZombieDying();

                // Call function to restart the game
                //PlayerManager.instance.KillPlayer();

                Time.timeScale = 1f;
                GameDeathImage.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;


        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
