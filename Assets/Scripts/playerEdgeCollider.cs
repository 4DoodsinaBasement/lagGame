using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEdgeCollider : MonoBehaviour
{
	void Update()
	{
		var dist = (this.transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		Vector3 playerSize = GetComponent<Renderer>().bounds.size;

		this.transform.position = new Vector3(
		Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 4, rightBorder - playerSize.x / 4),
		Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 4, bottomBorder - playerSize.y / 4),
		this.transform.position.z
		);
	}
}
