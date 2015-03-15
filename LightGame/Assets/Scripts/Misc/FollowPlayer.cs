using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	public GameObject player;

	public bool followW = true;
	public bool followH = true;

	public bool useOriginalPosition = true;

	private float w = 0, h = 0;

	public float height = 0f;
	public float width = 0f;
	public float depth = -11f;


	private Vector3 offset;
	private Vector3 originalPos;
	
	// Use this for initialization
	void Start () 
	{
		//save original position and create an offset based on player 
		originalPos = transform.position;
	}

	void Update()
	{
		//h and w are float
		//equivalents of folloH and folloW
		//these values can be used to zero out
		//play position as a modification on 
		//certain planes
		if (followH)
			h = 1;
		else
			h = 0;

		if (followW)
			w = 1;
		else
			w = 0;

		//when not using the original position
		//the object will snap to the player's position and will be offset by the values input
		//note: the object will only snap to what is enabled via followH and followW
		if (!useOriginalPosition) {
			transform.position = player.transform.position;
			transform.position = new Vector3 (player.transform.position.x * w + width, player.transform.position.y * h + height, depth);
		} else {
			//when using the original position we neglect the width and height floats and only use the objects original position 
			//and using player position to update it's position
			//width and height may be removed later if this method is sufficient 
			transform.position = new Vector3 (player.transform.position.x * w + originalPos.x, player.transform.position.y * h + originalPos.y, depth);
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//transform.position = new Vector3(player.transform.position.x * w + width, player.transform.position.y * h + height, depth) + offset;
	}
}
