using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int totalAlphabet = 0;
    public GameObject restartUI;

    // Start is called before the first frame update
    void Start()
    {
        restartUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Makes the object persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCount()
    {
        totalAlphabet++;
        if (totalAlphabet >= 5)
        {
            DisplayRestartUI();
        }
    }

    public void DisplayRestartUI()
    {
        restartUI.SetActive(true);
        if (restartUI != null)
        {
            restartUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Restart UI is not assigned or was destroyed.");
        }
        //StartCoroutine(WaitAndRestartGame(2f));
    }

    //public void StartGame()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //    //SceneManager.LoadScene("Background", LoadSceneMode.Additive);
    //}

    //private IEnumerator WaitAndRestartGame(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    StartGame();
    //}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restartUI.SetActive(false);
    }


}
