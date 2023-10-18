using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int totalAlphabet = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            DontDestroyOnLoad(gameObject); // Makes the object persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCount()
    {
        totalAlphabet++;
        // You can also add a check here to see if totalCoins >= 5 and then load the new scene
    }
}
