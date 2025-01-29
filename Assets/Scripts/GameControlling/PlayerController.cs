using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax; // Limits for player movement
}

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed; // Movement speed of the player
    public float tilt; // Tilt effect during movement
    public int weapon; // Active weapon type
    public int isGatlinging; // Gatling gun active flag
    public int isSniping; // Sniper gun active flag
    public int isShotguning; // Shotgun active flag
    public float gatlingTime; // Time remaining for Gatling gun
    public float snipingTime; // Time remaining for Sniper gun
    public float shotgunTime; // Time remaining for Shotgun
    public Boundary boundary; // Movement boundaries

    public GameObject shot_normal; // Normal shot prefab
    public GameObject shot_sniper; // Sniper shot prefab
    public GameObject EventSystem; // Reference to event system
    public Transform shotSpawn; // Main shot spawn point
    public Transform shotSpawn2; // Secondary spawn point for sniper
    public Transform shotSpawn3; // Additional spawn point for shotgun
    public Transform shotSpawn4; // Additional spawn point for shotgun
    public float fireRate; // Fire rate for weapons

    private Rigidbody rb; // Rigidbody component
    private float nextFire; // Timer for the next shot

    void Start()
    {
        // Initialize components and variables
        rb = GetComponent<Rigidbody>();
        weapon = 1;
        fireRate = 0.25f;
        isGatlinging = 0;
        isSniping = 0;
    }

    void Update()
    {
        // Handle shooting based on the active weapon
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (weapon == 1) // Normal shot
            {
                Instantiate(shot_normal, shotSpawn.position, shotSpawn.rotation);
            }
            else if (weapon == 2) // Sniper shot
            {
                Instantiate(shot_sniper, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot_sniper, shotSpawn2.position, shotSpawn.rotation);
            }
            else if (weapon == 3) // Shotgun
            {
                Instantiate(shot_normal, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot_normal, shotSpawn3.position, shotSpawn.rotation);
                Instantiate(shot_normal, shotSpawn4.position, shotSpawn.rotation);
            }

            GetComponent<AudioSource>().Play();
        }

        // Manage Gatling gun cooldown
        gatlingTime -= Time.deltaTime;
        if (gatlingTime <= 0 && isGatlinging == 1)
        {
            fireRate = 0.25f;
            isGatlinging = 0;
        }

        // Manage Sniper gun cooldown
        snipingTime -= Time.deltaTime;
        if (snipingTime <= 0 && isSniping == 1)
        {
            weapon = 1;
            isSniping = 0;
        }

        // Manage Shotgun cooldown
        shotgunTime -= Time.deltaTime;
        if (shotgunTime <= 0 && isShotguning == 1)
        {
            weapon = 1;
            isShotguning = 0;
        }
    }

    void FixedUpdate()
    {
        // Handle player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        // Clamp player position within boundaries
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        // Apply tilt based on movement
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    public void gatlingGun()
    {
        // Activate Gatling gun if no other weapon is active
        if (isSniping == 0 && isShotguning == 0)
        {
            fireRate = 0.15f;
            gatlingTime = 5;
            isGatlinging = 1;
        }
    }

    public void sniperGun()
    {
        // Activate Sniper gun if no other weapon is active
        if (isGatlinging == 0 && isShotguning == 0)
        {
            weapon = 2;
            snipingTime = 7.5f;
            isSniping = 1;
        }
    }

    public void shotgun()
    {
        // Activate Shotgun if no other weapon is active
        if (isGatlinging == 0 && isSniping == 0)
        {
            weapon = 3;
            shotgunTime = 5;
            isShotguning = 1;
        }
    }
}
