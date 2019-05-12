using UnityEngine;
using System.Collections;
using System;

public class CompleteCameraController : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public GameObject Panel;
    public GameObject option;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 localscale;
    private static bool state = false;
    private float size;
    // Use this for initialization
    void Start () 
    {

        localscale = transform.localScale;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        size = Camera.current.orthographicSize;
    }
    public void testoption()
    {
        calloption();
    }

   public void calloption()
    {
        Vector3 temp = new Vector3(option.transform.position.x, option.transform.position.y, -11f);
        transform.position = temp;
        transform.localScale = option.transform.localScale;

    }
    public void basicUpdate()
    {
        if (state != true)
        {
            transform.position = player.transform.position + offset;
            Time.timeScale = 1;
        }
        else Time.timeScale = 0;
            
    }
    void Update()
    {
        //state = PauseMenuScript.isPaused;

        basicUpdate();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Vector3 temp = new Vector3(Panel.transform.position.x, Panel.transform.position.y,-11f);
            transform.position = temp;
            transform.localScale = Panel.transform.localScale;
            state = state == false ? true : false;
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
             

    }

    public static bool getState()
    {
        return CompleteCameraController.state;
    }
    public static void setState(bool temp) { 
        CompleteCameraController.state = temp; 

    }
}
