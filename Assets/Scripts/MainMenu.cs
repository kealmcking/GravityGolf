using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioClip continueClip, retryClip;
    [SerializeField] AudioSource audioSource;

    public void QuitGame()
    {
        audioSource.PlayOneShot(retryClip);
        Application.Quit();
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(continueClip);
        SceneManager.LoadScene(1);
    }

}
