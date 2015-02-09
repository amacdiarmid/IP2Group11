using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

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
				size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
				RaycastHit2D hitUp = Physics2D.Raycast(origin + size, Vector2.up);
				if (hitUp)
				{
					Up = false;
					var tile = hitUp.collider.GetComponentInChildren<pathNodes>();
					tile.Down = false;
					tile.path = path;
					tile.recieveRay();
				}				
			}
			//send ray down
			if (Down == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
				RaycastHit2D hitDown = Physics2D.Raycast(origin - size, -Vector2.up);
				if (hitDown)
				{
					Down = false;
					var tile = hitDown.collider.GetComponentInChildren<pathNodes>();
					tile.Up = false;
					tile.path = path;
					tile.recieveRay();
				}
			}
			//send ray left
			if (Left == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
				RaycastHit2D hitLeft = Physics2D.Raycast(origin - size, -Vector2.right);
				if (hitLeft)
				{
					Left = false;
					var tile = hitLeft.collider.GetComponentInChildren<pathNodes>();
					tile.Right = false;
					tile.path = path;
					tile.recieveRay();
				}
			}
			//send ray right
			if (Right == true)
			{
				origin = new Vector2(this.transform.position.x, this.transform.position.y);
				size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
				RaycastHit2D hitRight = Physics2D.Raycast(origin + size, Vector2.right);
				if (hitRight)
				{
					Right = false;
					var tile = hitRight.collider.GetComponentInChildren<pathNodes>();
					tile.Left = false;
					tile.path = path;
					tile.recieveRay();
				}
			}
			SendRay = false;			
		}
	}

	public virtual void detectPath()
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

	public virtual void detectWall()
	{
		Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y);
		Vector2 size;
		Debug.Log("detect wall");
		//detect wall up
		size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
		RaycastHit2D hitUpW = Physics2D.Raycast(origin + size, Vector2.up);	
		if(hitUpW && hitUpW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Up = false;
		}
		//detect wall down
		size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
		RaycastHit2D hitDownW = Physics2D.Raycast(origin - size, -Vector2.up);
		if (hitDownW && hitDownW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Down = false;
		}
		//detect wall left
		size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
		RaycastHit2D hitLeftW = Physics2D.Raycast(origin - size, -Vector2.right);
		if (hitLeftW && hitLeftW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Left = false;
		}
		//detect wall right
		size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
		RaycastHit2D hitRightW = Physics2D.Raycast(origin + size, Vector2.right);
		if (hitRightW && hitRightW.collider.GetComponent<pathNodes>().Wall == true)
		{
			Debug.Log("wall");
			Right = false;
		}
	}

	public virtual void recieveRay()
	{
		//Debug.Log("node hit" + transform.position.x + transform.position.y);
		if (GotRay == false)
		{
			path.Add(transform.position);
			SendRay = true;
			GotRay = true;
		}		
	}
}