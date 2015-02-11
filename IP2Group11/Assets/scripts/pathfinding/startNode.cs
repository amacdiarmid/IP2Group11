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
		GotRay = false;
		end = unhiddenEnd;
		//send raycasts where ever there is a true	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startPath()
	{
		path.Add(transform.position);
		origin = new Vector2(this.transform.position.x, this.transform.position.y);
		//send ray up
		if (Up == true)
		{
			rayUp();
		}
		//send ray down
		if (Down == true)
		{
			rayDown();
		}
		//send ray left
		if (Left == true)
		{
			rayLeft();
		}
		//send ray right
		if (Right == true)
		{
			rayRight();
		}
	}
}
