using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelButtonScript : MonoBehaviour
{
    int clearedLevel;

    private void Awake()
    {
        clearedLevel = PlayerPrefs.GetInt("clearedLevel");
    }
    public void GoToLevel01()
    {
        SceneManager.LoadScene("Level01");
    }
}
