using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	
	// Public variables

	//horizontal speed limit and Acceleration

	public float speedCap = 4f;
	public float AccelMulti = 4f;

	//impulse force for jump
	public float jumpForce = 5f;

	//decelerater 
	public float friction = 1f;
	

	// Private variables
	private Animator anim;
	
	//jump and run controler
	private bool isGrounded;

	/// <canRun and CanJump>
	/// These might be removed later since
	/// isGrounded can accomplish the same task
	/// they will be kept for now incase more 
	/// control over the character is needed
	/// but are not actually being used
	/// <canRun and CanJump>
	private bool canJump;
	private bool canRun;
	
	//is also not actually being used
	//but being kept for now
	private bool canClimb;


	void Start() 
	{
		// Get animator component
		anim = GetComponent<Animator> ();

		isGrounded = false;
		canJump = false;
		canClimb = true;
		canRun = true;	
	}
	

	void FixedUpdate () 
	{
		float running = Input.GetAxisRaw ("Horizontal");
		float jumping = Input.GetAxisRaw ("Jump");

		//if the player is grounded (on ground or a jumpable object)
		if (isGrounded) 
		{
			//since the player is grounded, report the horizontal speed to the animator
			anim.SetFloat ("hSpeed", rigidbody2D.velocity.x );

			//this is possibly a temporary way of applying a "friction" or apposing force to a player to reduce sliding
			//it should only be applied when the user is moving left or right while grounded
			if(Mathf.Abs(rigidbody2D.velocity.x) > 0f)
			{
				//friction variable is public and editable from the UI
				rigidbody2D.AddForce( new Vector2( (rigidbody2D.velocity.x)/(-friction) , rigidbody2D.velocity.y));
			}
			//if the player is pressing left or right while grounded 
			if((Mathf.Abs(running)) > 0f)
			{
				//call the running function to apply horizontal force 
				run (running);
			}
			//if the player is pressing the jump key
			if (jumping > 0f) 
			{
				//call the jump function
				jump();
				
			}
		}

		//if the player can't jump then it must be falling or jumping
		if (!isGrounded) 
		{
			//update vertical velocity
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y );
		}
	}

	void jump()
	{
		// Set animator parameter
		anim.SetBool("isGrounded", false);
		
		// Use AddForce to allow gravity to affect descent
		rigidbody2D.AddForce( new Vector2(Input.GetAxisRaw("Horizontal"), jumpForce * Input.GetAxisRaw("Jump")), ForceMode2D.Impulse);
	}

	void run(float running)
	{
		//if the player is moving below the speedcap in either direction
		//speedCap is public and editable in the UI
		if(Mathf.Abs(rigidbody2D.velocity.x) < speedCap)
		{
			//activate the running bool
			anim.SetBool("isRunning", true);
			//add force either to the left or right of the player
			//AccelMulti is public and editable in the UI
			rigidbody2D.AddForce( new Vector2(running * AccelMulti, 0f)); //recently changed **** set y to 0
		}
	}


	/// <Setters and Getters>
	/// these functions are primarily used as
	/// an interface for outside classes so 
	/// they can access and modify the states
	/// of the player
	/// <Setters and Getters>



	//used by this and outside classes to set whether the player can jump
	public void setJumpStatus(bool state)
	{
		canJump = state;
	}

	//used by this and outside classes to set whether the player can run
	public void setRunStatus(bool state)
	{
		canRun = state;
	}

	public void setIsgrounded(bool state)
	{
		isGrounded = state;
	}


	//Getter methods

	//used by outside classes to see whether the player can climb
	public bool getClimbStatus()
	{
		return canClimb;
	}

	//used to see if the player is pressing down or up by other classes
	//returns between -1 and 1 if pressing down or up respectively
	//returns 0 if neither are pressed
	public float climbUpDown()
	{
		return (Input.GetAxisRaw ("Vertical"));
	}

	//used to see if the player is pressing left or right by other classes
	//returns between -1 and 1 if pressing left or right respectively
	//returns 0 if neither are pressed
	public float moveH()
	{
		return (Input.GetAxisRaw ("Horizontal"));
	}
	

}
