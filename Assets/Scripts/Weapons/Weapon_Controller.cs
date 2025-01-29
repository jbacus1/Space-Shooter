using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    // Variables
    public GameObject shot; // Projectile to spawn
    public Transform shotSpawn; // Spawn point for the projectile
    public float fireRate; // Time interval between shots
    public float delay; // Initial delay before firing starts

    private AudioSource audioSource; // Audio source for the firing sound

    void Start()
    {
        // Initialize audio source and start repeated firing
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        // Spawn the shot and play the firing sound
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
