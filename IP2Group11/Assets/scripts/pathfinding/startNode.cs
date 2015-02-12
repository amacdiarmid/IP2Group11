using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	public endNode unhiddenEnd;

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		//GotRay = false;
		end = unhiddenEnd;
		//send raycasts where ever there is a true	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startPath()
	{
		recieveRay();
	}
}
