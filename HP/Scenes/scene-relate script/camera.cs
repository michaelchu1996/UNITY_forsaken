using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10); // Camera follows the player but 6 to the right
    }
}
