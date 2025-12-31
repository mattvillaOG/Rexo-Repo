using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //the player compnent
    public PlayerController thePlayer;
    //the player's last recorded position position variable
    private Vector3 lastPlayerPosition;
    //used for recording the movement of the player for the camera to read
    private float distanceToMove;


    // Start is called before the first frame update
    void Start()
    {
        //get teh player by their script
        thePlayer = FindObjectOfType<PlayerController>();
        //the variable is now the players posiong
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //the distacne moved the current posion minus the last positoin, but x axis
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        //this transform (the camera) has a posiiton = to its posion, plus the distance it needs to move
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z );

        //the last recorded position variable is the current posiion of the player object
        lastPlayerPosition = thePlayer.transform.position;
    }
}
