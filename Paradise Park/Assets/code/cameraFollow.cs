using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    
    public GameObject player;
    private Vector3 equalizer;
	// Use this for initialization
	void Start () {
        equalizer = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //following the player for camera
        if(this.tag.Equals("MainCamera"))
        {
            this.transform.position = player.transform.position - equalizer;
            this.transform.position = player.transform.position - equalizer;
        }
        else
        {
            //this.transform.localPosition = player.transform.localPosition;
            this.transform.position = player.transform.position;
        }
        
    }
}
