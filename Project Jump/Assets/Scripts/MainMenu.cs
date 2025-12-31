using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //the main level
    public string playGameLevel;

    public GameObject startMenu;
    public GameObject howToPlayMenu;
    public GameObject creditsMenu;

    public AudioSource buttonSound;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
        buttonSound.Play();
    }

    public void HowToPlay()
    {
        startMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
        buttonSound.Play();
    }

    public void RollCredits()
    {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
        buttonSound.Play();
    }

    public void ReturtToMenu()
    {
        startMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        creditsMenu.SetActive(false);
        buttonSound.Play();
    }
}
