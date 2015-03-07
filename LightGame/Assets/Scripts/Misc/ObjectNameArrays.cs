/*
 * Install this file in the Assets/Scripts/Misc
 * 
 * To use include using misc; at the top of your class file.
 * 
 * Then instantiate ObjectNameArrays and use that to instantiate any arrays you need by calling the climable, jumpable, etc... methods
 */

using UnityEngine;
using System.Collections;

namespace misc
{
	public class ObjectNameArrays
	{
		private string[] ClimableArray = {"Box","Ladder"};
		private string[] JumpableArray = {"Ground", "Box", "Platform"};
		private string[] PickUpArray = {"Temp"};

		// Metzger additions 3/6
		private string[] PushableArray = {"Box"};				// pushables (logs, etc)

		public string[]	Climable()
		{
			return ClimableArray;
		}
		
		public string[]	Jumpable()
		{
			return JumpableArray;
		}
		
		public string[]	PickUp()
		{
			return PickUpArray;
		}
		
		public string[]	Pushable()
		{
			return PushableArray;
		}
	}
}