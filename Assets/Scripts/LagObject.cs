using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagObject
{
	private string command_internal;
	private float startTime_internal; 
	private float delay_internal;

	public LagObject(string command, float startTime, float delay)
	{
		command_internal = command;
		startTime_internal = startTime;
		delay_internal = delay;
	}

	public string GetCommand() { return command_internal; }
	public float GetStartTime() { return startTime_internal; }
	public float GetDelay() { return delay_internal; }
	public void SetDelay(float newDelay) { delay_internal = newDelay; }
}
