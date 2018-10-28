using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    [SerializeField] private bool MoveRight = true;
    [SerializeField] private float MoveSpeed = 40f;
    private Rigidbody2D rigidBody;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        float ms = MoveSpeed;
        if (!MoveRight)
        {
            ms = ms * -1;
        }

        rigidBody.AddForce(new Vector2(ms, 0f), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "box")
        {
            MoveRight = !MoveRight;
        }
    }
}
