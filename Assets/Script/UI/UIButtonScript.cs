using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonScript : MonoBehaviour
{
    public GameObject OptionPanel, PauseButton;

    public void setOptionPanelOn()
    {
        OptionPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void setOptionPanelOff()
    {
        OptionPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1.0f;
        initializeStatus();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        initializeStatus();
    }

    public void RePlay()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1.0f;
        initializeStatus();
    }

    public void initializeStatus()
    {
        PlayerPrefs.SetInt("PlayerLife", 5);
        PlayerPrefs.SetInt("PlayerBlade", 3);
        PlayerPrefs.SetInt("PlayerStone", 0);
    }
}
