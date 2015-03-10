using UnityEngine;
using System.Collections;

public class LedgeGrab : MonoBehaviour {

	//use these offsets to tweak the landing position of the player after climbing

	//horizontal offset (negative for left, positive for right)
	public float hOffset = 1.5f;
	//vertical offset (should always be positive)
	public float vOffset = 1.5f;

	/*
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "Player")
		{
			climb(other);
		}

	}
	*/

	void OnTriggerStay2D(Collider2D other) 
	{
		//if a player has toched a climb trigger, see if they want to climb
		if (other.gameObject.name == "Player")
		{
			PlayerMovement playerScript = other.GetComponent<PlayerMovement> ();
			//if player wants to climb, call the climb function and pass the collider
			if(playerScript.climbUpDown() > 0f)
			{
				climb(other);
			}
		}
		
	}



	void climb(Collider2D other)
	{

		GameObject player = other.gameObject;
		//allows us to get information from the player's movement script
		//allows us to control the player's Animator
		Animator playerAnim = player.GetComponent<Animator> ();


		//set ledge climb state to activate climb animation
		playerAnim.SetBool("ledgeClimb", true);
		//make the rigidbody kinematic for a smoother transition (may not be necessary)
		player.GetComponent<Rigidbody2D>().isKinematic = true;

		//get position of sensor (trigger)
		Vector2 sensor = transform.position;

		//get a landing position offset from the sensor(trigger)
		Vector2 landingPos = new Vector2 (sensor.x + hOffset, sensor.y + vOffset);

		//get the players position's
		Vector2 playerPos = other.gameObject.transform.position;

		//Calculate difference between player position and the landing 
		Vector2 landing = new Vector2 (landingPos.x - playerPos.x, landingPos.y - playerPos.y);

		//move the player to the landing position in relationg to world coordinates
		player.transform.Translate (landing, Space.World);


		//the player should no longer be climbing
		playerAnim.SetBool("ledgeClimb", false);
		//and the rigidbody's kinematic option can be removed
		player.GetComponent<Rigidbody2D>().isKinematic = false;


	}

}
