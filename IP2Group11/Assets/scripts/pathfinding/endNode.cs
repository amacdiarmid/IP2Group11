using UnityEngine;
using System.Collections;

public class endNode : pathNodes {

	public GameObject test;

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		GotRay = false;
		//send raycasts where ever there is a true		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void recieveRay()
	{
		if (done == false)
		{
			if (GotRay == false)
			{
				GotRay = true;
				done = true;
				path.Add(this.transform.position);
				int i = 0;
				foreach (var item in path)
				{ 
					i++;
				}
				test.GetComponent<LineRenderer>().SetVertexCount(i);
				i = 0;
				foreach (var item in path)
				{
					test.GetComponent<LineRenderer>().SetPosition(i, new Vector3(item.x, item.y, -1));
					i++;
				}
				test.GetComponent<LineRenderer>().enabled = true;
				Debug.Log("end path");
			}
		}
	}
}
