using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 startingForce = new Vector3(0f, 5f, 20f); 
    public Vector3 initialPosition = new Vector3(78.68f, 0f, 18.3f);
    public float bounceForce = 4f;
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply force to the Rigidbody on startup
            StartGame();
        }
    }

    void StartGame() 
    {
        rb.AddForce(startingForce, ForceMode.Impulse);
    }

    void ResetBall()
    {
        float delay = 0.4f;
        Vector3 resetForce = new Vector3(0f, 0f, 0f);
        rb.AddForce(resetForce, ForceMode.Impulse);
        Invoke("StartGame", delay);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        // If collides with Walls and Floor
        if (collision.gameObject.CompareTag("BackWall"))
        {
            // Calculate the bounce direction
            Vector3 backWallDirection = new Vector3(0f, 1f, -10f);
            rb.AddForce(backWallDirection, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Vector3 floorBounce = new Vector3(0f, 6.5f, 0f);
            rb.AddForce(floorBounce,ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            Vector3 rightWallBounce = new Vector3(-4f, 0f, 0f);
            rb.AddForce(rightWallBounce,ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            Vector3 leftWallBounce = new Vector3(4f, 0f, 0f);
            rb.AddForce(leftWallBounce,ForceMode.Impulse);
        }

        // If collides with Player Paddle
        if (collision.gameObject.CompareTag("Player"))
        {
            // Randmizes if it bounces Left or Right
            float randomValue = Random.Range(0f, 1f);
            Vector3 bounceDirection = new Vector3((randomValue < 0.5f) ? -2f : 2f, 6f, 20f);

            rb.velocity = bounceDirection.normalized * bounceForce;
        }

        // If collides Wall (Player's Side)
        if (collision.gameObject.CompareTag("PlayerWall"))
        {
            // Reset the ball's position to the initial position
            transform.position = initialPosition;
            ResetBall();
        }
        
    }
}
