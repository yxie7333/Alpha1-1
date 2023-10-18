using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Communicate with the GameManager to increase coin count
            GameManager.Instance.AddCount();

            // Optionally handle the scene change within the coin script
            if (GameManager.Instance.totalAlphabet >= 5)
            {
                // SceneManager.LoadScene("SceneName");
                Debug.Log("here");
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
