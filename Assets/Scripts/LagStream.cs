using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagStream : MonoBehaviour
{
	public float globalLagTime = 0.0f;
	public testMove playerScript;
	static List<LagObject> commandList = new List<LagObject>();
	
	// Use this for initialization
	void Start ()
	{
		Debug_ShowCommandList();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		UpdateCommandListLags();
		
		if (commandList.Count > 0)
		if (Time.time >= commandList[0].GetStartTime() + commandList[0].GetDelay())
		{
			playerScript.RunCommand(GetNextLagObject());
		}
	}

	// Use this to delay an action made by the player
	public void AddNewCommand(LagObject newLagObject)
	{
		commandList.Add(newLagObject);
	}

	LagObject GetNextLagObject()
	{
		LagObject nextCommand;

		if (commandList.Count > 0)
		{
			nextCommand = commandList[0];

			commandList.RemoveAt(0);
		}
		else
		{
			nextCommand = new LagObject(null, 0, 0);
		}
		
		Debug.Log(nextCommand.GetCommand() + " " + nextCommand.GetStartTime() + " " + nextCommand.GetDelay());
		return nextCommand;
	}

	void UpdateCommandListLags()
	{
		foreach (LagObject command in commandList)
		{
			command.SetDelay(globalLagTime);
		}
	}

	public void Debug_ShowCommandList()
	{
		string commands = ""; 
		
		foreach (LagObject command in commandList)
		{
			commands += command.GetCommand() + ", ";
		}
	}
}
