using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

	[HideInInspector] public bool Up;
	[HideInInspector] public bool Down;
	[HideInInspector] public bool Left;
	[HideInInspector] public bool Right;
	public bool Wall;
	[HideInInspector] public bool GotRay;
	[HideInInspector] public static bool done;

	public List<Vector2> path = new List<Vector2>();

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		GotRay = false;
		//send raycasts where ever there is a true	
		if (Wall == false)
		{
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public virtual void recieveRay()
	{
		if (done == false)
		{
			//Debug.Log("node hit" + transform.position.x + transform.position.y);
			if (GotRay == false)
			{
				GotRay = true;
				Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y);
				Vector2 size;
				path.Add(transform.position);
				//send ray up
				if (Up == true)
				{
					size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
					RaycastHit2D hitUp = Physics2D.Raycast(origin + size, Vector2.up);
					if (hitUp)
					{
						if (hitUp.collider.GetComponentInChildren<pathNodes>().Wall != true)
						{
							Up = false;
							var tile = hitUp.collider.GetComponentInChildren<pathNodes>();
							tile.Down = false;
							sendPath(tile);
						}
						
					}
				}
				//send ray down
				if (Down == true)
				{
					size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
					RaycastHit2D hitDown = Physics2D.Raycast(origin - size, -Vector2.up);
					if (hitDown)
					{
						if (hitDown.collider.GetComponentInChildren<pathNodes>().Wall != true)
						{
							Down = false;
							var tile = hitDown.collider.GetComponentInChildren<pathNodes>();
							tile.Up = false;
							sendPath(tile);
						}
					}
				}
				//send ray left
				if (Left == true)
				{
					size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
					RaycastHit2D hitLeft = Physics2D.Raycast(origin - size, -Vector2.right);
					if (hitLeft)
					{
						if (hitLeft.collider.GetComponentInChildren<pathNodes>().Wall != true)
						{
							Left = false;
							var tile = hitLeft.collider.GetComponentInChildren<pathNodes>();
							tile.Right = false;
							sendPath(tile);
						}
					}
				}
				//send ray right
				if (Right == true)
				{
					size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
					RaycastHit2D hitRight = Physics2D.Raycast(origin + size, Vector2.right);
					if (hitRight)
					{
						if (hitRight.collider.GetComponentInChildren<pathNodes>().Wall != true)
						{
							Right = false;
							var tile = hitRight.collider.GetComponentInChildren<pathNodes>();
							tile.Left = false;
							sendPath(tile);
						}
					}
				}
			}
		}		
	}

	public virtual void sendPath(pathNodes tile)
	{
		tile.path.Clear();
		foreach (var item in path)
		{
			tile.path.Add(item);
		}		
		tile.recieveRay();
	}
}