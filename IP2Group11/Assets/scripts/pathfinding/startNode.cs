using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	// Use this for initialization
	void Start () 
	{
		detectPath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startPath()
	{
		Vector2 origin;
		Vector2 size;
		//send ray up
		if (Up == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(0, collider2D.bounds.size.y / 2);
			RaycastHit2D hitUpS = Physics2D.Raycast(origin + size, Vector2.up);
			hitUpS.collider.GetComponent<pathNodes>().path = path;
			hitUpS.collider.GetComponent<pathNodes>().recieveRay();
		}
		//send ray down
		if (Down == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(0, -collider2D.bounds.size.y / 2);
			RaycastHit2D hitDownS = Physics2D.Raycast(origin + size, -Vector2.up);
			hitDownS.collider.GetComponent<pathNodes>().path = path;
			hitDownS.collider.GetComponent<pathNodes>().recieveRay();
		}
		//send ray left
		if (Left == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(-collider2D.bounds.size.y / 2, 0);
			RaycastHit2D hitLeftS = Physics2D.Raycast(origin + size, -Vector2.right);
			hitLeftS.collider.GetComponent<pathNodes>().path = path;
			hitLeftS.collider.GetComponent<pathNodes>().recieveRay();
		}
		//send ray right
		if (Right == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(collider2D.bounds.size.y / 2, 0);
			RaycastHit2D hitRightS = Physics2D.Raycast(origin + size, Vector2.right);
			hitRightS.collider.GetComponent<pathNodes>().path = path;
			hitRightS.collider.GetComponent<pathNodes>().recieveRay();
		}
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
