using UnityEngine;
using System.Collections;

public class endNode : pathNodes {

	public pathfindTest test;

	// Use this for initialization
	void Start () 
	{
		detectPath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void recieveRay()
	{
		if (GotRay == false)
		{
			GotRay = true;
			path.Add(this.transform.position);
			Debug.Log("end path");
		}	
	}
}
