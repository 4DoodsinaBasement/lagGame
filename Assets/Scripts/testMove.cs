using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
	public LagStream LagManager;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			LagManager.AddNewCommand(new LagObject("move right", Time.time, LagManager.globalLagTime));
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			LagManager.AddNewCommand(new LagObject("move left", Time.time, LagManager.globalLagTime));
		}
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			LagManager.AddNewCommand(new LagObject("jump", Time.time, LagManager.globalLagTime));
		}
	}

	public void RunCommand(LagObject command)
	{
		switch (command.GetCommand())
		{
			case "move right" : MoveRight(); break;
			case "move left" : MoveLeft(); break;
			case "jump" : Jump(); break;
		}
	}

	void MoveRight()
	{
		transform.Translate(1,0,0);
	}

	void MoveLeft()
	{
		transform.Translate(-1,0,0);
	}

	void Jump()
	{
		transform.Translate(0,1,0);
	}
}
