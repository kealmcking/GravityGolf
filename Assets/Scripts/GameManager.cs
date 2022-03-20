using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] BallControl ballControl;
    [SerializeField] int shotsTaken, bestShots, devBest;
    [SerializeField] TMP_Text shotsTakenText, timeTakenText;
    [SerializeField] GameObject endPanel;
    [SerializeField] float timeTaken;
    [SerializeField] int timeTakenSeconds;

    [SerializeField] TMP_Text endShotsTaken, endTimeTaken, endDevBest, endBestShots;

    [SerializeField] AudioClip continueClip, retryClip;
    [SerializeField] AudioSource audioSource;

    int nextLevelIndex;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        shotsTaken = ballControl.shotsTaken;
        shotsTakenText.text = $"Shots Taken: {shotsTaken}";
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        nextLevelIndex = currentLevelIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        TrackTime();
        UpdateShotsTakenText();
        LevelWon();
    }

    void TrackTime()
    {
        if (!ballControl.hasWon)
        {
            timeTaken += Time.deltaTime;
            timeTakenSeconds = (int)timeTaken % 60;
            timeTakenText.text = $"Time: {timeTakenSeconds}";
        }
    }

    void UpdateShotsTakenText()
    {
        shotsTaken = ballControl.shotsTaken;
        shotsTakenText.text = $"Shots Taken: {shotsTaken}";
    }

    void UpdateBestShots()
    {
        if (shotsTaken < bestShots)
        {
            bestShots = shotsTaken;
        }
    }

    void LevelWon()
    {
        if (ballControl.hasWon)
        {
            shotsTakenText.enabled = false;
            timeTakenText.enabled = false;
            endShotsTaken.text = $"Shots Taken: {shotsTaken}";
            endTimeTaken.text = $"Time Taken: {timeTakenSeconds}";
            endBestShots.text = $"Best Shots: {bestShots}";
            endPanel.SetActive(true);
        }
    }

    public void NextLevel()
    {
        audioSource.PlayOneShot(continueClip);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void Retry()
    {
        audioSource.PlayOneShot(retryClip);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
