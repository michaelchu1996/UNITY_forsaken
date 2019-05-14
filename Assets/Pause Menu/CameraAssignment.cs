using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAssignment : MonoBehaviour
{
    public Camera test;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = test.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompleteCameraController.getState() == false)
        {
            test.orthographicSize = size;
        }
    }
    void LateUpdate()
    {
        if(CompleteCameraController.getState() == true)
        {
            test.orthographicSize = 146f;
        }
    }
}
