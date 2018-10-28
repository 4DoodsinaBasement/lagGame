using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPortal : MonoBehaviour {

    [SerializeField] private string scene = "Level 1";
    [SerializeField] private string tag = "winPortal";

	Animator animator;
	Rigidbody2D rigidbody;

    // Use this for initialization
    void Start ()
	{
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == tag)
        {
            rigidbody.velocity = Vector3.zero;
			animator.SetInteger("AnimState", 6);
			SceneManager.LoadScene(scene);
        }
    }
}
