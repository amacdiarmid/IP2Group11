using UnityEngine;
using System.Collections;

public class endNode : pathNodes {

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

	public void detectWall()
	{
		Vector2 origin;
		Vector2 size;
		Debug.Log("detect wall");
		//detect wall up
		origin = new Vector2(this.transform.position.x, this.transform.position.y);
		size = new Vector2(0, collider2D.bounds.size.y / 2);
		RaycastHit2D hitUpW = Physics2D.Raycast(origin + size, Vector2.up);
		if (hitUpW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Up = false;
		}
		//detect wall down	
		origin = new Vector2(this.transform.position.x, this.transform.position.y);
		size = new Vector2(0, -collider2D.bounds.size.y / 2);
		RaycastHit2D hitDownW = Physics2D.Raycast(origin + size, -Vector2.up);
		if (hitDownW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Down = false;
		}
		//detect wall left
		origin = new Vector2(this.transform.position.x, this.transform.position.y);
		size = new Vector2(-collider2D.bounds.size.y / 2, 0);
		RaycastHit2D hitLeftW = Physics2D.Raycast(origin + size, -Vector2.right);
		if (hitLeftW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Left = false;
		}
		//detect wall right
		origin = new Vector2(this.transform.position.x, this.transform.position.y);
		size = new Vector2(collider2D.bounds.size.y / 2, 0);
		RaycastHit2D hitRightW = Physics2D.Raycast(origin + size, Vector2.right);
		if (hitRightW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Right = false;
		}
	}

	public void detectPath()
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		Wall = false;
		GotRay = false;
		SendRay = false;
		detectWall();
		//send raycasts where ever there is a true
	}
}
