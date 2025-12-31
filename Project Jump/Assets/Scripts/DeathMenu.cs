using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public AudioSource buttonSound;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        buttonSound.Play();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuLevel);
        buttonSound.Play();
    }
}
