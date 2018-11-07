using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickup : MonoBehaviour
{

	GameObject lagManager;

	void Start()
	{
		lagManager = GameObject.Find("Lag Manager");
		gameObject.SetActive(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			lagManager.GetComponent<LagStream>().globalLagTime = 0.0f;
			gameObject.SetActive(false);
		}
	}
}
