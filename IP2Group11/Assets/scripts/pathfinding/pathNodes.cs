using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum direction
{
	NE,
	SE,
	SW,
	NW,
	none
};

public class pathNodes : MonoBehaviour
{

	//varibles for the checked directions
	public bool NEChecked;
	public bool SWChecked;
	public bool NWChecked;
	public bool SEChecked;
	public bool Wall;
	private List<GameObject> path;
	private GameObject target;

	// Use this for initialization
	void Start()
	{
		NEChecked = false;
		SWChecked = false;
		NWChecked = false;
		SEChecked = false;
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
	}

	public GameObject getAdjacentTiles(direction tempDirect)
	{
		//set the adjacent tiles
		Vector2 size;
		Vector2 center = this.transform.position;
		Vector2 direct;
		//NE
		if (tempDirect == direction.NE)
		{
			size = new Vector2(GetComponent<Renderer>().bounds.size.x / 2, GetComponent<Renderer>().bounds.size.y / 2);
			direct = new Vector2(2, 1.2f);
			RaycastHit2D NEhit = Physics2D.Raycast(center + size, direct, Mathf.Infinity, LayerMask.GetMask("Tile"));
			if (NEhit)
			{
				return NEhit.collider.gameObject;
			}
		}
		//SE
		else if (tempDirect == direction.SE)
		{
			size = new Vector2(GetComponent<Renderer>().bounds.size.x / 2, -GetComponent<Renderer>().bounds.size.y / 2);
			direct = new Vector2(2, -1.2f);
			RaycastHit2D SEhit = Physics2D.Raycast(center + size, direct, Mathf.Infinity, LayerMask.GetMask("Tile"));
			if (SEhit)
			{
				return SEhit.collider.gameObject;
			}
		}
		//SW
		else if (tempDirect == direction.SW)
		{
			size = new Vector2(-GetComponent<Renderer>().bounds.size.x / 2, -GetComponent<Renderer>().bounds.size.y / 2);
			direct = new Vector2(-2, -1.2f);
			RaycastHit2D SWhit = Physics2D.Raycast(center + size, direct, Mathf.Infinity, LayerMask.GetMask("Tile"));
			if (SWhit)
			{
				return SWhit.collider.gameObject;
			}
		}
		//NW
		else
		{
			size = new Vector2(-GetComponent<Renderer>().bounds.size.x / 2, GetComponent<Renderer>().bounds.size.y / 2);
			direct = new Vector2(-2, 1.2f);
			RaycastHit2D NWhit = Physics2D.Raycast(center + size, direct, Mathf.Infinity, LayerMask.GetMask("Tile"));
			if (NWhit)
			{
				return NWhit.collider.gameObject;
			}
		}
		return null;
	}

	/// <summary>
	/// called whenever this tile has been hit by a raycast sent from another tile
	/// </summary>
	/// <returns>retuns true on the "recive ray" from reaching the endtile</returns>
	public virtual bool recieveRay(List<GameObject> tempPath, GameObject tempTarget, direction tempDirect)
	{
		path = tempPath;
		target = tempTarget;
		if (tempDirect == direction.NE)
		{
			SWChecked = true;
		}
		else if (tempDirect == direction.SE)
		{
			NWChecked = true;
		}
		else if (tempDirect == direction.SW)
		{
			NEChecked = true;
		}
		else if (tempDirect == direction.NW)
		{
			SEChecked = true;
		}
		bool topHalf = false;
		bool bottomHalf = false;
		bool sameX = false;
		bool rightHalf = false;
		bool leftHalf = false;
		bool sameY = false;

		if (this.transform.position.y < target.transform.position.y)
		{
			topHalf = true;
		}
		else if (this.transform.position.y > target.transform.position.y)
		{
			bottomHalf = true;
		}
		else
		{
			sameX = true;
		}
		if (this.transform.position.x < target.transform.position.y)
		{
			rightHalf = true;
		}
		else if (this.transform.position.x > target.transform.position.x)
		{
			leftHalf = true;
		}
		else
		{
			sameY = true;
		}

		if (topHalf == true && rightHalf == true)
		{
			//1st priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//3th priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//4th priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (topHalf == true && leftHalf == true)
		{
			//1st priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			//4th priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (bottomHalf == true && rightHalf == true)
		{
			//1st priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//4th priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (bottomHalf == true && leftHalf == true)
		{
			//1st priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//4th priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (sameX == true && rightHalf == true)
		{
			//1st priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//3th priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//4th priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (sameX == true && leftHalf == true)
		{
			//1st priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//4th priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (topHalf == true && sameY == true)
		{
			//1st priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//4th priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			return false;
		}
		else if (bottomHalf == true && sameY == true)
		{
			//1st priority
			if (SWChecked == false)
			{
				SWChecked = true;
				if (rayDirection(direction.SW) == true)
				{
					return true;
				}
			}
			//2nd priority
			if (SEChecked == false)
			{
				SEChecked = true;
				if (rayDirection(direction.SE) == true)
				{
					return true;
				}
			}
			//3rd priority
			if (NWChecked == false)
			{
				NWChecked = true;
				if (rayDirection(direction.NW) == true)
				{
					return true;
				}
			}
			//4th priority
			if (NEChecked == false)
			{
				NEChecked = true;
				if (rayDirection(direction.NE) == true)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	/// <summary>
	/// this will send the ray in an upward direction
	/// in the iso view this is NE
	/// </summary>
	/// <returns>return depending on teh "recieved Ray"</returns>
	public virtual bool rayDirection(direction tempDirect)
	{
		pathNodes tempTile;
		//this sets the distance from the origin that the ray cast will start	
		if (tempDirect == direction.NE)
		{
			tempTile = getAdjacentTiles(direction.NE).GetComponent<pathNodes>();
		}
		else if (tempDirect == direction.SE)
		{
			tempTile = getAdjacentTiles(direction.SE).GetComponent<pathNodes>();

		}
		else if (tempDirect == direction.SW)
		{
			tempTile = getAdjacentTiles(direction.SW).GetComponent<pathNodes>();
		}
		else
		{
			tempTile = getAdjacentTiles(direction.NW).GetComponent<pathNodes>();
		}
		//remove blank tiles and wall tiles
		if (!tempTile || tempTile.Wall == true)
		{
			return false;
		}
		//if the object hit is a tile and is not a wall (or tower or terrain) send on the ray
		if (tempTile.recieveRay(path, target, tempDirect) == true)
		{
			path.Add(this.gameObject);
			return true;
		}
		else
		{
			return false;
		}
	}
}