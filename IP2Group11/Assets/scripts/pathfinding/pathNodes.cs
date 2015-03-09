using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

	public bool Up;
	public bool Down;
	public bool Left;
	public bool Right;
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

	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public virtual bool recieveRay()
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
						if (rayLeft() == true)
						{
							return true;
						}
					}
				}
				else
				{
					//first prioraty
					if (Right == true)
					{
						Right = false;
						if (rayRight() == true)
						{
							return true;
						}
					}
				}
				//if it needs to go up more than down 
				if (end.transform.position.y <= this.transform.position.y)
				{
					//second prioraty
					if (Up == true)
					{
						Up = false;
						if(rayUp() == true)
						{
							return true;
						}				
					}
				}
				else
				{
					//second prioraty
					if (Down == true)
					{
						Down = false;
						if(rayDown() == true)
						{
							return true;
						}
						
					}
				}
				//third priority
				if (Right == true)
				{
					Right = false;
					if (rayRight() == true)
					{
						return true;
					}
				}
				else if(Left == true)
				{
					Left = false;
					if (rayLeft() == true)
					{
						return true;
					}
				}
				//fourth priority
				if (Up == true)
				{
					Up = false;
					if (rayUp() == true)
					{
						return true;
					}	
				}
				else if(Down == true)
				{
					Down = false;
					if (rayDown() == true)
					{
						return true;
					}
				}
				else
				{
					return false;
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
						if (rayUp() == true)
						{
							return true;
						}	
					}
				}
				else
				{
					//first prioraty
					if (Down == true)
					{
						Down = false;
						if (rayDown() == true)
						{
							return true;
						}
					}
				}
				//if it needs to go left more than right
				if (end.transform.position.x <= this.transform.position.x)
				{
					//second prioraty
					if (Left == true)
					{
						Left = false;
						if (rayLeft() == true)
						{
							return true;
						}
					}
				}
				else
				{
					//second prioraty
					if (Right == true)
					{
						Right = false;
						if (rayRight() == true)
						{
							return true;
						}
					}
				}
				//third priority
				if (Up == true)
				{
					Up = false;
					if (rayUp() == true)
					{
						return true;
					}	
				}
				else if(Down == true)
				{
					Down = false;
					if (rayDown() == true)
					{
						return true;
					}
				}
				//fourth priority
				if (Right == true)
				{
					Right = false;
					if (rayRight() == true)
					{
						return true;
					}
				}
				else if(Left == true)
				{
					Left = false;
					if (rayLeft() == true)
					{
						return true;
					}
				}
				else
				{
					return false;
				}
			}
		}
		return false;
	}

	public virtual bool sendPath(pathNodes tile)
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
		if(tile.recieveRay() == true)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public virtual bool rayUp()
	{
		size = new Vector2(renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1,1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				if(sendPath(tile) == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (recieveRay() == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else
		{
			if (recieveRay() == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public virtual bool rayDown()
	{
		size = new Vector2(-renderer.bounds.size.x / 2, -renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1,-1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				if (sendPath(tile) == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (recieveRay() == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else
		{
			if (recieveRay() == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public virtual bool rayLeft()
	{
		size = new Vector2(-renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1, 1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				if (sendPath(tile) == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (recieveRay() == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else
		{
			if (recieveRay() == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public virtual bool rayRight()
	{
		size = new Vector2(renderer.bounds.size.x/2, -renderer.bounds.size.y/2);
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1, -1));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				if (sendPath(tile) == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (recieveRay() == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		else
		{
			if (recieveRay() == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}