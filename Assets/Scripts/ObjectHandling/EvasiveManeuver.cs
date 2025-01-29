using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    // Variables
    public Vector2 maneuverTime; // Time range for maneuvers
    public Vector2 maneuverWait; // Time range to wait between maneuvers
    public Vector2 startWait; // Time range before starting maneuvers
    public float dodge; // Maximum dodge distance
    public float smoothing; // Smoothness of the maneuver
    public float tilt; // Tilt of the object during movement
    public Boundary boundary; // Movement boundaries

    private float currentSpeed; // Current speed of the object
    private float targetManeuver; // Target maneuver position
    private Rigidbody rb; // Rigidbody component

    void Start()
    {
        // Initialize the Rigidbody and set initial speed
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        // Wait before starting maneuvers
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            // Set a random target maneuver
            targetManeuver = Random.Range(1, dodge * -Mathf.Sign(transform.position.x));
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));

            // Reset maneuver
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        // Smoothly transition to the target maneuver
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);

        // Clamp position within boundaries
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        // Apply tilt based on movement direction
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
