using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        // Setting Left & Right Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput,0f).normalized;

        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement) 
    {
        // Moving the player
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

}
