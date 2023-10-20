using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Use List to dynamically restore the A, P, P, L, E objects
    public List<GameObject> alphabetObjects = new List<GameObject>();

    public Text resultText;  // 对UI Text的引用


	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        Debug.Log("DiceSides was read!");

        // Start to roll dice in 5 second intervals
        StartCoroutine(RollDiceAutomatically());

        // 自动获取场景中所有的A, P, P, L, E对象
        alphabetObjects.AddRange(GameObject.FindGameObjectsWithTag("Alphabet"));
	}
    private IEnumerator RollDiceAutomatically()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine("RollTheDice");
        }
    }

    // // If you left click over the dice then RollTheDice coroutine is started
    // private void OnMouseDown()
    // {
    //     Debug.Log("Dice was clicked!");
    //     StartCoroutine("RollTheDice");
    // }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        // Remove alphabet objects based on dice value
        RemoveAlphabetObjects(finalSide);
        
        UpdateUIText(finalSide);  // 更新UI文本

        // Show final dice value in Console
        Debug.Log(finalSide);
    }
    private void RemoveAlphabetObjects(int number) {
        for(int i = 0; i < number; i++) {
            if(alphabetObjects.Count > 0) {
                int index = Random.Range(0, alphabetObjects.Count);  // randomly delete the alphabet object
                Destroy(alphabetObjects[index]);
                alphabetObjects.RemoveAt(index);
            }
        }
    }
    private void UpdateUIText(int number) {
        resultText.text = "- " + number + " characters";  // 根据筛子的数字更新UI文本
    }
}