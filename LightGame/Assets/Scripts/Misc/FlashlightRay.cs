using UnityEngine;
using System.Collections;

/// <Flashlight Ray>
/// This script should be bound to the flashlight or a light source 
/// and is used to detect trigger or monsters in order to provoke
/// an action.
/// </Flashlight Ray>


public class FlashlightRay : MonoBehaviour {

	public int reflections = 3;
	public float rayLength = 13f;

	private Ray2D ray;
	private GameObject target;

	//any scripts that will be controlled by this ray should be declared here
	//this script controls light trigger game objects
	private LightTrigger targetController;

	void Update()
	{
		//get a gameobject from the castRay function
		target = castRay (transform.position, transform.right, rayLength, 0);

		//if the target is not null
		if (target) 
		{
			//create an if statement for any object that will be affect by the light ray
			//this if statment will check for gameobjects named "Light Trigger"
			if (target.name == "Light Trigger") {
				targetController = target.GetComponent<LightTrigger> ();
				targetController.setStateTrue ();
			}
		}
	}

	//give an origin and direction
	//cast from that origin
	//return gameObject
	GameObject castRay(Vector2 origin, Vector2 direction, float length, int reflected)
	{
		
		//here we get a collider from hitinfo. When the ray is not hitting anything it's 
		//return type is null so hitinfo will be null


		//here the loop is basically just spinning through quick enough to catch any reflections that may occur
		//if none occur then it will just redraw the same ray three times. This method saves the game from crashing 
		//since less loop cycles will occur then if we set the increment to only occur if there's an actual reflection
		
			while(reflected <= reflections)
			{
				//if the ray is hitting a gameobject (the ray is not returning null)
				if (Physics2D.Raycast(origin, direction, rayLength)) 
				{
					//define a ray
					ray = new Ray2D(origin,direction);
					//then cast the ray, collecting any info that may be returned
					RaycastHit2D hitinfo = Physics2D.Raycast(ray.origin, ray.direction, rayLength);

					//draw the beam	
					//Debug.DrawRay(ray.origin, ray.direction * 50, Color.cyan);


					//if the ray hits a mirror, reflect
					if(hitinfo.collider.gameObject.name == "Mirror")
					{
						//a reflection is caused by redefining the origin and direction of the
						//beam
						direction = Vector3.Reflect(ray.direction, hitinfo.normal); 
						origin = hitinfo.point;
						
					//otherwise return whatever was hit
					}else
						return hitinfo.collider.gameObject;
					
				//if nothing was hit increment reflected regardless (to avoid crashing)
				//and recast another ray
				}
				reflected++;
			}
			return null;
								
		}


	}



