using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller : MonoBehaviour
{
    // Variables
    public float scrollSpeed; // Speed at which the background scrolls
    public float tileSizeZ; // Size of the tile in the Z direction

    private Vector3 startPosition; // Starting position of the background

    void Start()
    {
        // Record the starting position of the background
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on time and scroll speed
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
