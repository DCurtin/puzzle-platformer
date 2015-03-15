using UnityEngine;
using System.Collections;

public class BGTextureScrolling : MonoBehaviour 
{


	private float x = 0f;

	//a value between 1 and 0 which modifies how slowly the texture will scroll
	//1 being equall to the players velocity.x and 0 being stationary 
	public float speedMod = 0.001f;
	public GameObject player;


	void Update () 
	{
		float playerSpeed = player.rigidbody2D.velocity.x;

		if (playerSpeed > 0) 
		{
			//increment a value based on the velovity of the player and speed modified
			//using deltaTime seems to smooth out the scrolling a little better
			x += Time.deltaTime * playerSpeed * speedMod;
			if (x > 1.0f) 
			{
				//if the value gets to the end of the cylce reset it
				x -= 1.0f;
			}

		}else if (playerSpeed < 0) 
		{
			x += Time.deltaTime * playerSpeed * speedMod;
			if (x < -1.0) 
			{
				x += 1.0f;
			}
		}

		//offset the texture by x 
		//TODO set up paralaxing for jumping and climbing (vertical displacement)
		renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(x,0f));
	
	}


}
