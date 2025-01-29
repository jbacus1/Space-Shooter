using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Variables
    public GameObject hazard_1; // First type of hazard
    public GameObject hazard_2; // Second type of hazard
    public GameObject hazard_3; // Third type of hazard
    public GameObject hazard_Enemy; // Enemy hazard
    public GameObject powerUp; // First type of power-up
    public GameObject powerUp2; // Second type of power-up
    public GameObject powerUp3; // Third type of power-up
    public Vector3 spawnValues; // Spawn position range
    public int hazardCount; // Number of hazards per wave
    public int randomizer; // Randomizer for hazard selection
    public int score; // Current score
    public float spawnWait; // Time between spawns
    public float startWait; // Initial delay before spawning
    public float waveWait; // Delay between waves
    public Hi_Score HiScore; // Reference to Hi_Score script

    public Text scoreText; // UI Text for score
    public Text gameOverText; // UI Text for game over message
    public Text onslaughtText; // UI Text for onslaught message
    public Text tutorialText_1; // UI Text for tutorial instruction 1
    public Text tutorialText_2; // UI Text for tutorial instruction 2
    public Text tutorialText_3; // UI Text for tutorial instruction 3
    public Text restartText; // UI Text for explaining restart

    private bool gameOver; // Game over state
    private bool restart; // Restart state
    private int canOnslaught; // Flag to trigger onslaught mode

    void Start()
    {
        // Initialize variables and UI elements
        gameOver = false;
        restart = false;
        score = 0;
        randomizer = 1;
        canOnslaught = 0;
        gameOverText.text = "";
        onslaughtText.text = "";
        restartText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
        tutorialText_1.text = "Use W, A, S, & D to move your ship around";
        tutorialText_2.text = "Left click your mouse to fire your laser";
        tutorialText_3.text = "The white cubes are power-ups for your ship!";
    }

    void Update()
    {
        if (restart) 
        {
            if (Input.GetKeyDown (KeyCode.R)) 
        		{
        			Application.LoadLevel (Application.loadedLevel);
        		}
        }

        // Randomize hazard selection and clear tutorial text after time
        randomizer += Random.Range(1, 10);
        if (randomizer > 43)
        {
            randomizer = 1;
        }

        if (Time.time > 8)
        {
            tutorialText_1.text = "";
            tutorialText_2.text = "";
            tutorialText_3.text = "";
        }
    }

    IEnumerator SpawnWaves()
    {
        // Spawn hazards in waves
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                if (randomizer <= 10)
                {
                    Instantiate(hazard_1, spawnPosition, spawnRotation);
                }
                else if (randomizer <= 20)
                {
                    Instantiate(hazard_2, spawnPosition, spawnRotation);
                }
                else if (randomizer <= 30)
                {
                    Instantiate(hazard_3, spawnPosition, spawnRotation);
                }
                else if (randomizer <= 40)
                {
                    Instantiate(hazard_Enemy, spawnPosition, spawnRotation);
                }
                else if (randomizer == 41)
                {
                    Instantiate(powerUp, spawnPosition, spawnRotation);
                }
                else if (randomizer == 42)
                {
                    Instantiate(powerUp2, spawnPosition, spawnRotation);
                }
                else
                {
                    Instantiate(powerUp3, spawnPosition, spawnRotation);
                }

                yield return new WaitForSeconds(spawnWait);
            }
            hazardCount++;
            spawnWait -= 0.01f;
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        // Add to score and update UI
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        // Update the score UI
        scoreText.text = "Score: " + score;
        if (score >= 1000 && canOnslaught == 0)
        {
            hazardCount += 9999;
            spawnWait -= 0.15f;
            onslaughtText.text = "ONSLAUGHT!!!";
            canOnslaught = 1;
        }
    }

    public void GameOver()
    {
        // Handle game over logic
        gameOverText.text = "Game Over";
        onslaughtText.text = "";
        restartText.text = "Press 'R' to Restart";
        HiScore.SaveScore();
        gameOver = true;
    }

    public void ResartGame()
    {
        // Restart the game
        Application.LoadLevel(Application.loadedLevel);
    }
}
