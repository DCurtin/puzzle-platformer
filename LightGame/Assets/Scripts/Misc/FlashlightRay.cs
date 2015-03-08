using UnityEngine;
using System.Collections;

public class FlashlightRay : MonoBehaviour {

	public float rayLength = 13f;


	void Update()
	{
		 
		RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, rayLength);

		if (hitinfo.collider != null) 
		{
			if(hitinfo.collider.gameObject.name == "Light Trigger")
			{
				LightTrigger lightScript = hitinfo.collider.GetComponent<LightTrigger>();
				lightScript.setStateTrue();
				lightScript.setStateFalse();
				

			}
		}
		

	}

}
