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
		player = GetComponentInParent<PlayerMovement>();
		objectArrays = new ObjectNameArrays();
		
		JumpableArray = objectArrays.Jumpable();
	}
	
	public bool getJumpStatus()
	{
		return canJump;
	}

	void OnTriggerStay2D(Collider2D other) 
	{
		// check if it's one of the objects player can jump off
		foreach (string jumpable in JumpableArray) 
		{

			// if it is, allow player to jump
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
