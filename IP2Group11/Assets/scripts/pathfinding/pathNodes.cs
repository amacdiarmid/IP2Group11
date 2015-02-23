﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

	[HideInInspector] public bool Up;
	[HideInInspector] public bool Down;
	[HideInInspector] public bool Left;
	[HideInInspector] public bool Right;
	public bool Wall;
	//[HideInInspector] public bool GotRay;
	[HideInInspector] public static bool done;
	[HideInInspector] public Vector2 origin;
	[HideInInspector] public Vector2 size;
	[HideInInspector] public static endNode end;

	public List<Vector2> path = new List<Vector2>();

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;	
		if (Wall == false)
		{
			//this.gameObject.GetComponent<MeshRenderer>().enabled = false;
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
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			//this is the priority of the ray
			//if it needs to go horizontal more than vertical 
			if (end.transform.position.x - this.transform.position.x <= end.transform.position.y - this.transform.position.y)
			{
				//if it needs to go left more than right
				if (end.transform.position.x <= this.transform.position.x)
				{
					//first prioraty
					if (Left == true)
					{
						Left = false;
						rayLeft();
					}
				}
				else
				{
					//first prioraty
					if (Right == true)
					{
						Right = false;
						rayRight();
					}
				}
				//if it needs to go up more than down 
				if (end.transform.position.y <= this.transform.position.y)
				{
					//second prioraty
					if (Up == true)
					{
						Up = false;
						rayUp();
					}
				}
				else
				{
					//second prioraty
					if (Down == true)
					{
						Down = false;
						rayDown();
					}
				}
				//third priority
				if (Right == true)
				{
					Right = false;
					rayRight();
				}
				else if(Left == true)
				{
					Left = false;
					rayLeft();
				}
				//fourth priority
				if (Up == true)
				{
					Up = false;
					rayUp();
				}
				else if(Down == true)
				{
					Down = false;
					rayDown();
				}
			}
			else
			{
				//if it needs to go up more than down 
				if (end.transform.position.y <= this.transform.position.y)
				{
					//first prioraty
					if (Up == true)
					{
						Up = false;
						rayUp();
					}
				}
				else
				{
					//first prioraty
					if (Down == true)
					{
						Down = false;
						rayDown();
					}
				}
				//if it needs to go left more than right
				if (end.transform.position.x <= this.transform.position.x)
				{
					//second prioraty
					if (Left == true)
					{
						Left = false;
						rayLeft();
					}
				}
				else
				{
					//second prioraty
					if (Right == true)
					{
						Right = false;
						rayRight();
					}
				}
				//third priority
				if (Up == true)
				{
					Up = false;
					rayUp();
				}
				else if(Down == true)
				{
					Down = false;
					rayDown();
				}
				//fourth priority
				if (Right == true)
				{
					Right = false;
					rayRight();
				}
				else if(Left == true)
				{
					Left = false;
					rayLeft();
				}
			}
		}		
	}

	public virtual void sendPath(pathNodes tile)
	{
		if (!path.Contains(tile.transform.position))
		{
			tile.path.Clear();
			path.Add(transform.position);
			foreach (var item in path)
			{			
				tile.path.Add(item);
			}			
		}	
		tile.recieveRay();
	}

	public virtual void rayUp()
	{
		size = new Vector2(renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1,1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				sendPath(tile);
			}
			else
			{
				recieveRay();
			}
		}
		else
		{
			recieveRay();
		}
	}

	public virtual void rayDown()
	{
		size = new Vector2(-renderer.bounds.size.x / 2, -renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1,-1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				sendPath(tile);
			}
			else
			{
				recieveRay();
			}
		}
		else
		{
			recieveRay();
		}
	}

	public virtual void rayLeft()
	{
		size = new Vector2(-renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1, 1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				sendPath(tile);
			}
			else
			{
				recieveRay();
			}
		}
		else
		{
			recieveRay();
		}
	}

	public virtual void rayRight()
	{
		size = new Vector2(renderer.bounds.size.x/2, -renderer.bounds.size.y/2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1, -1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				sendPath(tile);
			}
			else
			{
				recieveRay();
			}
		}
		else
		{
			recieveRay();
		}
	}
}