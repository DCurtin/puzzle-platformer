/*
 * This script can NOT go on GameObjects disabled by it (tagged "LightToggle")
 * 3/6 - it's on FlashlightMover 
 */

using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour 
{
	// array of components making up flashlight
	private GameObject[] lights;
	// toggle: true = lights on
	private bool toggle;

	private void Awake()
	{
		lights = GameObject.FindGameObjectsWithTag("LightToggle");
		toggle = true;
	}

	// check for keypress every frame
	private void Update() 
	{
		// clicked right mouse
		if (Input.GetMouseButtonDown(1))
		{
			if (toggle)
			{
				SetLights(false);
			}
			else
			{
				SetLights(true);
			}
		}
	}

	// toggle every component of the flashlight
	private void SetLights(bool t)
	{
		foreach (GameObject light in lights) 
		{
			light.SetActive(t);
		}
		toggle = t;
	}

	// get light state (check for object interaction)
	public bool get_toggle()
	{
		return toggle;
	}
}