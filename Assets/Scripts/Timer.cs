using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Logger logger;
    // public GameObject watchout;
    public NPCController npcController;

    public TMP_Text timerText; // Use Unity's default Text component
    public float totalTimeInSeconds = 60; // 1 minute in seconds 
    private float currentTime;
    private bool ended = false;

    void Start()
    {
        logger = FindObjectOfType<Logger>();
        npcController = FindObjectOfType<NPCController>();

        currentTime = totalTimeInSeconds; // Initialize the timer
        StartCoroutine(WatchoutThing());
    }

    void Update()
    {
        UpdateTimerDisplay();
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrease the time
        }
        else if (!ended)
        {
            ended = true;
            currentTime = 0; // Ensure it doesn't go negative
            OnTimerEnd();
        }
    }

    IEnumerator WatchoutThing()
    {
        logger.Log("Watch Out!");
        yield return new WaitForSeconds(0.5f);
        // watchout.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        // watchout.SetActive(false);
        logger.Log("End Watch Out! Sign");
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(currentTime % 60); // Calculate seconds

        timerText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        // Code to execute when the timer ends
        logger.Log("Timer has ended! the game is finished");
        npcController.stopGenerating();
    }
}
