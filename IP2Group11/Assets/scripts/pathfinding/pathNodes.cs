using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

	//up isnt leaving collider
 	//left and right not working
	//down isnt working

	//trail ist reaching finish (not going up or across?)

	public bool Up;
	public bool Down;
	public bool Left;
	public bool Right;
	public bool Wall;
	protected bool GotRay;
	protected bool SendRay;

	public List<Vector2> path = new List<Vector2>();

	// Use this for initialization
	void Start () 
	{
		detectPath();
	}
	
	// Update is called once per frame
	void Update () 
	{

		//on recieving first raycast
		if (SendRay == true)
		{		
			Vector2 origin;
			Vector2 size;
			//send ray up
			if (Up == true)
			{
				origin = new Vector2(this.transform.position.x,this.transform.position.y);
				size = new Vector2(0, collider2D.bounds.size.y / 2);
				RaycastHit2D hitUp = Physics2D.Raycast(origin+size, Vector2.up);
				var tile = hitUp.collider.GetComponentInChildren<pathNodes>();
				tile.path = path;
				tile.recieveRay();
			}
			//send ray down
			if (Down == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2(0, -collider2D.bounds.size.y / 2);
				RaycastHit2D hitDown = Physics2D.Raycast(this.transform.position, -Vector2.up);
				var tile = hitDown.collider.GetComponentInChildren<pathNodes>();
				tile.path = path;
				tile.recieveRay();
			}
			//send ray left
			if (Left == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2(-collider2D.bounds.size.y / 2, 0);
				RaycastHit2D hitLeft = Physics2D.Raycast(this.transform.position, -Vector2.right);
				var tile = hitLeft.collider.GetComponentInChildren<pathNodes>();
				tile.path = path;
				tile.recieveRay();
			}
			//send ray right
			if (Right == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2(collider2D.bounds.size.y / 2, 0);
				RaycastHit2D hitRight = Physics2D.Raycast(this.transform.position, Vector2.right);
				var tile = hitRight.collider.GetComponentInChildren<pathNodes>();
				tile.path = path;
				tile.recieveRay();
			}
			SendRay = false;
			GotRay = true;			
		}
	}

	public void detectPath()
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		//Wall = false;
		GotRay = false;
		SendRay = false;
		detectWall();
		//send raycasts where ever there is a true
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
		if(hitUpW.collider.GetComponent<pathNodes>().Wall == true)
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

	public virtual void recieveRay()
	{
		Debug.Log("node hit" + transform.position.x + transform.position.y);
		if (GotRay == false)
		{
			SendRay = true;
		}
		
	}
}