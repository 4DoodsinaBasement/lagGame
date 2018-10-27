using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    private bool LeftCollision = false;
    private bool RightCollision = false;
    
    [SerializeField] private Transform LeftCheck;
    [SerializeField] private Transform RightCheck;

    [SerializeField] private LayerMask itsCamera;
    [SerializeField] private LayerMask itsWall;
                           // A mask determining what is ground to the character

    private Vector2 collision = new Vector2(0.2f, 0.2f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        
        CheckCollision();
        if (LeftCollision && RightCollision)
        {
            SceneManager.LoadScene("Level 1");
        }

    }


    void CheckCollision()
    {
        LeftCollision = false;
        RightCollision = false;


        Collider2D[] colliders1 = Physics2D.OverlapBoxAll(LeftCheck.position, collision, itsCamera);
        for (int i = 0; i < colliders1.Length; i++)
        {
            if (colliders1[i].gameObject != gameObject)
                LeftCollision = true;
        }

        Collider2D[] colliders2 = Physics2D.OverlapBoxAll(RightCheck.position, collision, itsWall);
        for (int j = 0; j < colliders2.Length; j++)
        {
            if (colliders2[j].gameObject != gameObject)
                RightCollision = true;
        }

  
    }




}
