using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathNodes : MonoBehaviour {

	//varibles for the checked directions
	public bool Up;
	public bool Down;
	public bool Left;
	public bool Right;
	public bool Wall;
	//static bool to see if the path has been completed
	[HideInInspector] public static bool done;
	//the location of the center of this tile
	[HideInInspector] public Vector2 origin;
	//the distance from the center of the tile so the raycast does not hit itself  
	[HideInInspector] public Vector2 size;
	//the end of the pathfind (the object we are trying to find
	[HideInInspector] public static endNode end;
	//teh current path form the start to this object
	public List<Vector2> path = new List<Vector2>();
	//the layer for the tiles (this was found out after the pathfinding was completed and it means that the hiding of colliders is no longer needed)
	private int layerMask;

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
	}

	/// <summary>
	/// called whenever this tile has been hit by a raycast sent from another tile
	/// </summary>
	/// <returns>retuns true on the "recive ray" from reaching the endtile</returns>
	public virtual bool recieveRay()
	{
		//if the static done is true the it has reached endtile and will stop all other tile from searching
		if (done == false)
		{
			//the current conter of the tile(this could and shoud be in the start method)
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
						//the tile has checked this direction now
						Left = false;
						if (rayLeft() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}
					}
				}
				else
				{
					//first prioraty
					if (Right == true)
					{
						//the tile has checked this direction now
						Right = false;
						if (rayRight() == true)
						{
							//this is if the "recieved ray" has reached the endtile
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
						//the tile has checked this direction now
						Up = false;
						if(rayUp() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}				
					}
				}
				else
				{
					//second prioraty
					if (Down == true)
					{
						//the tile has checked this direction now
						Down = false;
						if(rayDown() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}
						
					}
				}
				//third priority
				if (Right == true)
				{
					//the tile has checked this direction now
					Right = false;
					if (rayRight() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				else if(Left == true)
				{
					//the tile has checked this direction now
					Left = false;
					if (rayLeft() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				//fourth priority
				if (Up == true)
				{
					//the tile has checked this direction now
					Up = false;
					if (rayUp() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}	
				}
				else if(Down == true)
				{
					//the tile has checked this direction now
					Down = false;
					if (rayDown() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				else
				{
					//this is if the tile has ran out of directions to go and therefore has not reached the endtile 
					//so the "recieved ray" will now cascade througth the previous tiles setting them to retun false
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
						//the tile has checked this direction now
						Up = false;
						if (rayUp() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}	
					}
				}
				else
				{
					//first prioraty
					if (Down == true)
					{
						//the tile has checked this direction now
						Down = false;
						if (rayDown() == true)
						{
							//this is if the "recieved ray" has reached the endtile
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
						//the tile has checked this direction now
						Left = false;
						if (rayLeft() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}
					}
				}
				else
				{
					//second prioraty
					if (Right == true)
					{
						//the tile has checked this direction now
						Right = false;
						if (rayRight() == true)
						{
							//this is if the "recieved ray" has reached the endtile
							return true;
						}
					}
				}
				//third priority
				if (Up == true)
				{
					//the tile has checked this direction now
					Up = false;
					if (rayUp() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}	
				}
				else if(Down == true)
				{
					//the tile has checked this direction now
					Down = false;
					if (rayDown() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				//fourth priority
				if (Right == true)
				{
					//the tile has checked this direction now
					Right = false;
					if (rayRight() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				else if(Left == true)
				{
					//the tile has checked this direction now
					Left = false;
					if (rayLeft() == true)
					{
						//this is if the "recieved ray" has reached the endtile
						return true;
					}
				}
				else
				{
					//this is if the tile has ran out of directions to go and therefore has not reached the endtile 
					//so the "recieved ray" will now cascade througth the previous tiles setting them to retun false
					return false;
				}
			}
		}
		//this is if the tile has ran out of directions to go and therefore has not reached the endtile 
		//so the "recieved ray" will now cascade througth the previous tiles setting them to retun false
		return false;
	}

	/// <summary>
	/// this will send the current path stored in this object to the next tile to continue the path
	/// the paramiter is the next tile (hit by the raycast)
	/// </summary>
	/// <param name="tile"></param>
	/// <returns>will return true on the "recieved ray" returning true from hitting the endtile</returns>
	public virtual bool sendPath(pathNodes tile)
	{
		//if the path list does not contain the next tile add the list to the next tile (binary searching idea)
		if (!path.Contains(tile.transform.position))
		{
			//clear the tile of the old path from pervious searches
			tile.path.Clear();
			//add the current tile to the list before sending the list on
			path.Add(transform.position);
			foreach (var item in path)
			{			
				//for every location in the path add it to the next tile list
				tile.path.Add(item);
			}			
		}
		//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
		if(tile.recieveRay() == true)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// this will send the ray in an upward direction
	/// in the iso view this is NE
	/// </summary>
	/// <returns>return depending on teh "recieved Ray"</returns>
	public virtual bool rayUp()
	{
		//this sets the distance from the origin that the ray cast will start
		size = new Vector2(renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		//this will send a raycast froma point in a direction to find the next tile 
		//(the layer mask was not in the first few tests this is why there is a method to hide the colliders do they didnt get in they way)
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1, 1), Mathf.Infinity, LayerMask.GetMask("Tile"));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				//if the object hit is a tile and is not a wall (or tower or terrain) send on the ray
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
			//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
	/// <summary>
	/// this will send the ray in a downward direction
	/// in the iso view this is SW
	/// </summary>
	/// <returns>return depending on teh "recieved Ray"</returns>
	public virtual bool rayDown()
	{
		//this sets the distance from the origin that the ray cast will start
		size = new Vector2(-renderer.bounds.size.x / 2, -renderer.bounds.size.y / 2);
		//this will send a raycast froma point in a direction to find the next tile 
		//(the layer mask was not in the first few tests this is why there is a method to hide the colliders do they didnt get in they way)
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1, -1), Mathf.Infinity, LayerMask.GetMask("Tile"));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				//if the object hit is a tile and is not a wall (or tower or terrain) send on the ray
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
			//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
	/// <summary>
	/// this will send the ray in a left direction
	/// in the iso view this is NW
	/// </summary>
	/// <returns>return depending on teh "recieved Ray"</returns>
	public virtual bool rayLeft()
	{
		//this sets the distance from the origin that the ray cast will start
		size = new Vector2(-renderer.bounds.size.x / 2, renderer.bounds.size.y / 2);
		//this will send a raycast froma point in a direction to find the next tile 
		//(the layer mask was not in the first few tests this is why there is a method to hide the colliders do they didnt get in they way)
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(-1, 1), Mathf.Infinity, LayerMask.GetMask("Tile"));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{
				//if the object hit is a tile and is not a wall (or tower or terrain) send on the ray
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
			//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
	/// <summary>
	/// this will send the ray in a right direction
	/// in the iso view this is SE
	/// </summary>
	/// <returns>return depending on teh "recieved Ray"</returns>
	public virtual bool rayRight()
	{
		//this sets the distance from the origin that the ray cast will start
		size = new Vector2(renderer.bounds.size.x / 2, -renderer.bounds.size.y / 2);
		//this will send a raycast froma point in a direction to find the next tile 
		//(the layer mask was not in the first few tests this is why there is a method to hide the colliders do they didnt get in they way)
		RaycastHit2D hit = Physics2D.Raycast(origin + size, new Vector2(1, -1), Mathf.Infinity, LayerMask.GetMask("Tile"));
		if (hit)
		{
			if (hit.collider.GetComponentInChildren<pathNodes>().Wall != true)
			{

				//if the object hit is a tile and is not a wall (or tower or terrain) send on the ray
				var tile = hit.collider.GetComponentInChildren<pathNodes>();
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
				//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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
			//this is on recieving the "recieve Ray" depending on if the path was sucsessful or not 
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