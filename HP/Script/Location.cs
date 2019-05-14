using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public GameObject camera;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private bool state;
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - camera.transform.position;
        state = CompleteCameraController.getState();
    }
    void Update()
    {
        if(state!=true)
        transform.position = camera.transform.position + offset;
        state = CompleteCameraController.getState();
    }
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = camera.transform.position + offset;
    }
}
