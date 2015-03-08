using UnityEngine;
using System.Collections;

/// <Flashlight Ray>
/// This script should be bound to the flashlight or a light source 
/// and is used to detect trigger or monsters in order to provoke
/// an action.
/// </Flashlight Ray>


public class FlashlightRay : MonoBehaviour {

	public float rayLength = 13f;

	void Update()
	{
		//this line instantiates a Raycast hit simmilar to a collider2D that gives us info
		//about what the ray is hitting. The raycast itself takes in a position, a direction and
		//distance and returns the RaycastHit when it interacts with something
		RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, rayLength);

		//here we get a collider from hitinfo. When the ray is not hitting anything it's 
		//return type is null so hitinfo will be null
		if (hitinfo.collider != null) 
		{
			//here we get the game object's name and compare it to a Ligh trigger
			if(hitinfo.collider.gameObject.name == "Light Trigger")
			{
				//here we preform the approriate action for this object
				//which is running a set of methods after getting the script from the
				//light trigger object
				LightTrigger lightScript = hitinfo.collider.GetComponent<LightTrigger>();
				lightScript.setStateTrue();
				lightScript.setStateFalse();
				

			}
		}
		

	}

}
