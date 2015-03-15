using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	public GameObject player;

	public bool followW = true;
	public bool followH = true;

	private float w = 0, h = 0;

	public float height = 0f;
	public float width = 0f;
	public float depth = -11f;


	private Vector3 offset;
	
	// Use this for initialization
	void Start () 
	{
		if (followH)
			h = 1;
		if (followW)
			w = 1;
	 
		offset = new Vector3( transform.position.x * w + width  , transform.position.y * h + height , depth);	
		transform.position = offset;
	}

	void Update()
	{
		transform.position = new Vector3(player.transform.position.x * w + width, player.transform.position.y * h + height, depth) + offset;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//transform.position = new Vector3(player.transform.position.x * w + width, player.transform.position.y * h + height, depth) + offset;
	}
}
