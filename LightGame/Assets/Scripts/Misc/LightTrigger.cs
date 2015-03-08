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
		StopAllCoroutines();
		if (onTimer) {
			StartCoroutine ("timer");
		}
	}

	public bool getOnState()
	{
		return onState;
	}
			
		

	IEnumerator timer() {
		yield return new WaitForSeconds(waitTime);
		onState = false;

	}
	
}
