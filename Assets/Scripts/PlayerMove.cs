using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public LagStream LagManager;
	
	
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	

	[SerializeField] private float jumpForce = 400f;	
	private Rigidbody2D rigidBody;
	[Range(0, .3f)] [SerializeField] private float smooth = .05f;
	private Vector3 velocity = Vector3.zero;
	private bool facingRight = true;
	private bool grounded;
    [SerializeField] private bool airControl = true;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask itsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;
	private Vector2 collision = new Vector2(1f, 0.2f);


	
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{	
		CheckCollision();

		if (grounded || airControl)
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{ LagManager.AddNewCommand(new LagObject("move left", Time.time, LagManager.globalLagTime)); }

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{ LagManager.AddNewCommand(new LagObject("move right", Time.time, LagManager.globalLagTime)); }

			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
			{ LagManager.AddNewCommand(new LagObject("jump", Time.time, LagManager.globalLagTime)); }
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
		
		Vector3 targetVelocity = new Vector2(runSpeed * Time.fixedDeltaTime * -10f, rigidBody.velocity.y);
		// And then smoothing it out and applying it to the character
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, smooth);
	}

	void MoveRight ()
	{
		if (!facingRight) { Flip(); }
		
		Vector3 targetVelocity = new Vector2(runSpeed * Time.fixedDeltaTime * 10f, rigidBody.velocity.y);
		// And then smoothing it out and applying it to the character
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, smooth);
	}

	void Jump ()
	{
		if (grounded)
		{
            // Add a vertical force to the player.
            grounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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
