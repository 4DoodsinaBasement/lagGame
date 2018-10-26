using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour 
{
	public float cameraSpeed = 3f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(cameraSpeed * 0.01f, 0, 0);
	}
}
