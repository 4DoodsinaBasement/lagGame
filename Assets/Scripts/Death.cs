using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

	public bool touchingBox = false;
	public bool touchingWall = false; 
	public bool touchingSpike = false; 
	public string scene = "Lose_Menu";
	void FixedUpdate()
	{
		Debug.Log("touchingBox: " + touchingBox);
		Debug.Log("touchingWall" + touchingWall);
		if (touchingBox && touchingWall)
		{
			SceneManager.LoadScene(scene);
		}
	}
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if ( collider.gameObject.tag == "camera")
        {	
            touchingWall = true;
        }
		if ( collider.gameObject.tag == "box")
        {	
            touchingBox = true;
        }
		
	}
	
	private void OnTriggerExit2D(Collider2D collider)
	{
		if ( collider.gameObject.tag == "camera")
        {	
            touchingWall = false;
        }
		if ( collider.gameObject.tag == "box")
        {	
            touchingBox = false;
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
			touchingSpike = true;
            SceneManager.LoadScene(scene);
        }
    }

}
