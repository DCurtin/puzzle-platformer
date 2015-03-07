using UnityEngine;
using System.Collections;

/// <LightDetector>
/// This script requires a 2D colider on it's own object
/// and a door object with a liftScript to be assigned as 
/// one of it's variables. It also requires a colider attached 
/// to an object named "Flashlight" that will overlap with 
/// this object's collider; the flashlight collider will probably 
/// be a polygon collider made in the shape of the flashlight's beam. 
/// 
/// Note: Using polygon colider allows triggering through walls, a
/// fix or alternative method should be considered
/// </LightDetector>


public class LightDetector : MonoBehaviour {

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
	void OnTriggerEnter2D(Collider2D other) 
	{

		if (other.name == "Flashlight") 
		{
			onState = true;

		}

	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.name == "Flashlight") 
		{
			if(onTimer)
			{
				StartCoroutine("timer");
			}
			
		}
		
	}

	IEnumerator timer() {
		yield return new WaitForSeconds(waitTime);
		onState = false;

	}
	
}
