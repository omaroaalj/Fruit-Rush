using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
   	player =  GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) 
	{
	   player.velocity = new Vector3(0, 7, 0);
	}

	 if (Input.GetKey("d")) 
	{
	   player.velocity = new Vector3(3, 0, 0);
	}

	 if (Input.GetKey("a")) 
	{
	   player.velocity = new Vector3(-3, 0, 0);
	}

	if (Input.GetKey("w")) 
	{
	   player.velocity = new Vector3(0, 7, 0);
	}
	
    }
}
