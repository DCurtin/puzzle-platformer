using UnityEngine;
using System.Collections;

public class ClimbLadder : MonoBehaviour {

	//how fast the player can climb and strafe on the ladder
	public float climbSpeed = 01f;
	//used to identify when player is climbing
	private bool isClimbing;


	void OnTriggerStay2D(Collider2D other) 
	{
		//if player has entered the ladder
		if (other.gameObject.name == "Player")
		{
			//call the climb function to see if the player wants to climb
			climb(other);
		}
		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//after exiting the ladder
		if (other.gameObject.name == "Player")
		{
			//get player animator, set climbing to false, as well as AnimBool
			Animator playerAnim = other.gameObject.GetComponent<Animator> ();
			isClimbing = false;
			playerAnim.SetBool("climbingLadder", false);
			//turn gravity back on
			other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		}

	}


	void climb(Collider2D other)
	{

		
		//allows us to apply translates on the player
		GameObject player = other.gameObject;
		PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
		Animator playerAnim = player.GetComponent<Animator> ();

		
		//getClimbStatus checks to see if rawAxis "Vertical" is being pressed. Check if we're climbing already
		if( Mathf.Abs( playerScript.climbUpDown()) > 0f && isClimbing == false) 
		{
			//set climbing, Animator, cut any current velocity to eliminate sliding, set gravity to 0 
			isClimbing = true;
			playerAnim.SetBool("climbingLadder", true);
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			player.GetComponent<Rigidbody2D>().gravityScale = 0;

		}
		if(isClimbing)
		{
			playerScript.setIsgrounded(false);
			//create a vector for vertical and horizontal displacement
			Vector2 climbing = new Vector2(climbSpeed * playerScript.moveH(), climbSpeed * playerScript.climbUpDown());

			//apply vector with Translate for smooth motion along the ladder
			player.transform.Translate (climbing * Time.deltaTime);
		}


	}
	
}


