using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;

    public void PlayGame () 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
    }

    public void ResumeButton() 
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
    }
}
