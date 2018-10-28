using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

	public bool touchingBox = false;
	public bool touchingWall = false; 

	void FixedUpdate()
	{
		if (touchingBox && touchingWall)
		{
			SceneManager.LoadScene("Level 1");
		}
	}
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if ( collider.gameObject.tag == "camera")
        {	
            touchingWall = true;
        }
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
		if ( collision.gameObject.tag == "box")
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
	}

	private void OnCollisionExit2D(Collision2D collision)
    {
		if ( collision.gameObject.tag == "box")
        {	
            touchingBox = false;
        }
    }

}
