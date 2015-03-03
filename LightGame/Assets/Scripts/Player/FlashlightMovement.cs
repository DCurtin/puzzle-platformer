using UnityEngine;
using System.Collections;

public class FlashlightMovement : MonoBehaviour {

	void FixedUpdate ()
	{


		
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
	}
}
