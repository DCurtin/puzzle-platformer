using UnityEngine;
using System.Collections;
using misc;

public class PlayerCollisionDetection : MonoBehaviour {

	private bool canJump;
	private PlayerMovement player;

	//object arrays
	private ObjectNameArrays objectArrays;
	private string[] JumpableArray;




	void Start()
	{
		canJump = false;
		player = GetComponentInParent<PlayerMovement> ();
		objectArrays = new ObjectNameArrays ();
		
		JumpableArray = objectArrays.Jumpable ();

	}
	
	public bool getJumpStatus()
	{
		return canJump;
	}


	void OnTriggerEnter2D(Collider2D other) 
	{

		foreach (string jumpable in JumpableArray) 
		{

			if(other.name == jumpable)
			{
				player.setIsgrounded(true);
			}

		}



	}

	
	void OnTriggerExit2D(Collider2D other) 
	{

		foreach (string jumpable in JumpableArray) 
		{

			if(other.name == jumpable)
			{
				player.setIsgrounded(false);
			}

		}
	
	}
}
