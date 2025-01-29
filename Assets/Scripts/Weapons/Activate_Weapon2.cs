using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Weapon2 : MonoBehaviour
{
    // Variables
    public PlayerController playerController; // Reference to the PlayerController script
    public GameObject player; // Reference to the player GameObject

    void Start()
    {
        // Find and assign the PlayerController component
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Ignore collisions with Boundary or Enemy objects
        if (other.CompareTag("Enemy") || other.CompareTag("Boundary"))
        {
            return;
        }

        // Activate Sniper gun if the player collides
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerController.sniperGun();
        }
    }
}
