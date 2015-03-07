using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	/// <summary>
	/// This script should in one way or another
	/// move a door. Two ways of doing this have been 
	/// preposed. 
	/// 
	/// 1. Eliminate the doors colider and play an
	/// animation of the door opening sideways
	/// 
	/// 2. have the door open vertically. By sliding it
	/// up with a transform.
	/// 
	/// To use: Attach this script to a door 
	/// (thin square w/ 2D colider) and set the approriate 
	/// openHeight. Use the isOpen check box to test it.
	/// note: When door is attached to lightDetector, the 
	/// check box will be unusable.
	/// </summary>

	public bool isOpen;
	public float openHeight;
	public float openSpeed;

	public GameObject input;

	private Vector3 defaultPos;
	

	void Start ()
	{
	 
		isOpen = false;
		openHeight = 10f;
		openSpeed = 3f;

		defaultPos = this.transform.position;
	}


	void FixedUpdate ()
	{
		if (isOpen ) {
			openDoor ();
		} else 
		{
			closeDoor ();
		}

	}

	void openDoor()
	{
		//if door is below or equall to the open position
		if(transform.position.y <= defaultPos.y + openHeight)
		{
			transform.Translate(0, openSpeed * Time.deltaTime, 0);
		}
	}
		
	void closeDoor()
	{
		//if door is above the close position
		if(transform.position.y > defaultPos.y)
		{
			transform.Translate(0, -openSpeed * Time.deltaTime, 0);
		}

	}
}
