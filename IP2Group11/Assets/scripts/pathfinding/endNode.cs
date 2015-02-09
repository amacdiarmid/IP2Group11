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
		Debug.Log("end path");
	}
}
