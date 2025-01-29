using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour
{
    // Variables
    public GameObject explosion; // Explosion effect for collision
    public GameObject playerExplosion; // Explosion effect for player collision
    public int scoreValue; // Score value for destroying this object
    public GameController gameController; // Reference to the GameController
    public Killme killMe; // Reference to a KillMe script (unused)
    public GameObject bolt; // Reference to a projectile (unused)

    void Start()
    {
        // Find and assign the GameController component
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Ignore collisions with non-relevant objects
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp"))
        {
            return;
        }

        // Create explosion effect and destroy the other object
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

        // Handle player collision
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);
        }

        // Add score and destroy this object
        gameController.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
