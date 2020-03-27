using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovingBlock : MonoBehaviour
{
    private Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    private Vector2 newPostion;
    //public string currentState;
    private float speed;
    //private float resetTime;

    // Use this for initialization
    void Start()
    {
        //ChangeTarget();
        //resetTime = 5;
        speed = (float)1.5;
        movingPlatform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(movingPlatform.position.x - position1.position.x) > .01)
        {
            movingPlatform.position = Vector2.Lerp(movingPlatform.position, position1.position, speed * Time.deltaTime);
        }           
        else if (Mathf.Abs(movingPlatform.position.x - position2.position.x) > .01)
        {
            movingPlatform.position = Vector2.Lerp(movingPlatform.position, position2.position, speed * Time.deltaTime);
        }
        else
        {                //position 1 diff                                           //position 2 diff
            if(Mathf.Abs(movingPlatform.position.x - position1.position.x) < Mathf.Abs(movingPlatform.position.x - position2.position.x) )
                movingPlatform.position = Vector2.Lerp(movingPlatform.position, position1.position, speed * Time.deltaTime);

        }
    }

}
