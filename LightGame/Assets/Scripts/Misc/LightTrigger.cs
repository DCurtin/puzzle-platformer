using UnityEngine;
using System.Collections;

/// <LightTrigger>
/// This script requires a 2D colider on it's own object
/// and a door object with a liftScript to be assigned as 
/// one of it's variables. 
/// 
/// When hit by a raycast light source; which is typically
/// the player's flashlight. It's onState will be triggered 
/// by the flashlight
/// </LightDetector>


public class LightTrigger : MonoBehaviour {

	public bool onTimer = false;
	public int waitTime = 5;
	public bool onState = false;

	public GameObject liftObj;
	private LiftScript liftScript;

	void Start()
	{
		liftScript = liftObj.GetComponent<LiftScript> ();

	}


	void Update()
	{
		//set the bound liftscrip to open or closed based on
		//the triggers onState
		if (onState) {

			liftScript.isOpen = true;

		} else 
		{
			liftScript.isOpen = false;
		}
	}


	// Use this for initialization
	public void setStateTrue()
	{

			onState = true;
	}

	//A light trigger can only be set false if
	//it's onTimer bool is true
	public void setStateFalse()
	{
		//if any other coroutines are running,
		//stop them and if onTimer is set true
		//create a new coroutine with a fresh timer.
		StopAllCoroutines();
		if (onTimer) {
			StartCoroutine ("timer");
		}
	}

	public bool getOnState()
	{
		return onState;
	}
			
		
	//this is a coroutine that when run will pause for a given time before
	//changing the onState to false. This function is used for switches that 
	//can be toggled
	IEnumerator timer() {
		yield return new WaitForSeconds(waitTime);
		onState = false;

	}
	
}
