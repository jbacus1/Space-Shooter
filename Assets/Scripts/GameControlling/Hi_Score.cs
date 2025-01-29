using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hi_Score : MonoBehaviour
{
    // Variables
    public int hiScore; // Current high score
    public GameController gameController; // Reference to the GameController
    public Text hiScoreText; // UI Text for the high score
    public Text newHiScoreText; // UI Text for new high score message

    void Start()
    {
        // Initialize references and UI elements
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        hiScoreText.text = "Hi-Score: " + PlayerPrefs.GetInt("Hi-Score");
        newHiScoreText.text = "";
    }

    public void SaveScore()
    {
        // Save and update the high score
        hiScore = gameController.score;
        hiScoreText.text = "";
        if (hiScore > PlayerPrefs.GetInt("Hi-Score"))
        {
            newHiScoreText.text = "New Hi-Score!!!";
            PlayerPrefs.SetInt("Hi-Score", hiScore);
        }
    }
}
