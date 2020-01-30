using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving1 : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public int scoreValue;
    private PlayerController gameController;
    

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("Player");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void FixedUpdate()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers and pingpong the movement.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));
    }

    public void TakeDamage(int damage)
    {
        if (damage == 1)
        {
            Debug.Log("Hit");
            gameController.AddScore(scoreValue);
            Die();

            
        }

    }

    void Die()
    {
        
        Destroy(gameObject);
    }
}