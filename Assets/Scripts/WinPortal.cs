using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPortal : MonoBehaviour {

    [SerializeField] private string scene = "Animation_Scene";
    [SerializeField] private string tag = "winPortal";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
