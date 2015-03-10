/*
 * objectArrays from misc namespace could be combined with PlayerCollisionDetection.cs,
 * but they apply to different colliders and could be left here intentionally too
 */

using UnityEngine;
using System.Collections;
using misc;

public class PlayerObjectInteraction : MonoBehaviour 
{
	// GameObject holding FlashlightController.cs goes in the editor
	public FlashlightController light;
	// PlayerMovement.cs is on the same Player object as this script tho
	private PlayerMovement movement;

	// player meeting conditions to PUSH / PULL object
	private bool isActing;
	// player is CURRENTLY pushing / pulling the object
	private bool isPushing;

	// smaller than the player movement cap
	public float speedCap = 3f;

	// object arrays (misc)
	private ObjectNameArrays objectArrays;
	private string[] PushableArray;

	void Start()
	{
		movement = GetComponent<PlayerMovement>();
		isActing = false;
		isPushing = false;

		// misc
		objectArrays = new ObjectNameArrays();
		PushableArray = objectArrays.Pushable();
	}

	private void Update () 
	{
		// holding left mouse && flashlight OFF
		if (Input.GetMouseButton(0) && !light.get_toggle())
		{
			isActing = true;
		}
		else
		{
			isActing = false;
			isPushing = false;
		}
	}

	// TODO ...ewwwwww... clean this up
	private void OnTriggerStay2D(Collider2D coll)
	{
		// check if it's a pushable object
		foreach (string pushable in PushableArray) 
		{
			float collPos = coll.gameObject.transform.position.x;

			// if player acting, move with player
			if(coll.gameObject.name == pushable && 
			   isActing && 
			   Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < speedCap)
			{
				isPushing = true;

				// moving left
				if (movement.moveH() == -1f)
				{
					// if player on left (P,C)
					if (transform.position.x < collPos)
					{
						// apply force to collider
						coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-250f,0,0));
					}
					else // (C,P)
					{
						// apply force to player
						GetComponent<Rigidbody2D>().AddForce(new Vector3(-250f,0,0));
					}
				}
				// moving right
				else if (movement.moveH() == 1f)
				{
					// if player on left (P,C)
					if (transform.position.x < collPos)
					{
						// apply force to player
						GetComponent<Rigidbody2D>().AddForce(new Vector3(250f,0,0));
					}
					else // (C,P)
					{
						// apply force to collider
						coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(250f,0,0));
					}
				}
			}
		}
	}

	// get acting state (for preventing excessive movement)
	public bool get_isPushing()
	{
		return isPushing;
	}
}