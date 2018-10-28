using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float runSpeed = 40f;
	public float jumpForce = 15;
	[Range(0, .3f)] public float smooth = .05f;
    public bool airControl = true;							// Whether or not a player can steer while jumping;
	public LayerMask itsGround;							// A mask determining what is ground to the character
	public Transform groundCheck;
	
	LagStream LagManager;
	Animator animator;

	float horizontalMove = 0f;
	Rigidbody2D rigidBody;
	Vector3 velocity = Vector3.zero;
	bool facingRight = true;
	bool grounded;
	Vector2 collision = new Vector2(1f, 0.2f);


	
	void Start()
	{
		LagManager = GameObject.Find("Lag Manager").GetComponent<LagStream>();
		rigidBody = GetComponent<Rigidbody2D>();

		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{	
		CheckCollision();

		if (/*grounded || airControl ||*/ true)
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				LagManager.AddNewCommand(new LagObject("move left", Time.time, LagManager.globalLagTime));
				//Debug.Log("Player wants to move left");
			}

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{ 
				LagManager.AddNewCommand(new LagObject("move right", Time.time, LagManager.globalLagTime));
				//Debug.Log("Player wants to move right");
			}

			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
			{ 
				LagManager.AddNewCommand(new LagObject("jump", Time.time, LagManager.globalLagTime));
				//Debug.Log("Player wants to jump"); 
			}

			UpdateIdleAnimation();
		}
	}

	// ------------------------------------ //
	// --- Commands and Command Routing --- //
	// ------------------------------------ //
	public void RunCommand(LagObject command)
	{
		switch (command.GetCommand())
		{
			case "move right" : MoveRight(); break;
			case "move left" : MoveLeft(); break;
			case "jump" : Jump(); break;
		}
	}

	void MoveLeft ()
	{
		if (facingRight) { Flip(); }
		animator.SetInteger("AnimState", 2);

		Vector3 targetVelocity = new Vector2(runSpeed * Time.fixedDeltaTime * -10f, rigidBody.velocity.y);
		// And then smoothing it out and applying it to the character
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, smooth);
	}

	void MoveRight ()
	{
		if (!facingRight) { Flip(); }
		animator.SetInteger("AnimState", 2);
		
		Vector3 targetVelocity = new Vector2(runSpeed * Time.fixedDeltaTime * 10f, rigidBody.velocity.y);
		// And then smoothing it out and applying it to the character
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, smooth);
	}

	void Jump ()
	{
		if (grounded)
		{
            animator.SetInteger("AnimState", 3);
			// Add a vertical force to the player.
            grounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
		}
	}

	void UpdateIdleAnimation()
	{
		if (rigidBody.velocity == new Vector2(0,0))
		{
			animator.SetInteger("AnimState", 1);
		}
	}

	// -------------------- //
	// --- Housekeeping --- //
	// -------------------- //
	void Flip()
	{
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void CheckCollision ()
	{
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, collision, itsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				grounded = true;
		}
	}
}
