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
	public bool debug;

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
				if (debug)
				{
					Debug.Log(this.gameObject + " " + NEhit.collider.gameObject);
				}
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
				if (debug)
				{
					Debug.Log(this.gameObject + " " + SEhit.collider.gameObject);
				}
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
				if (debug)
				{
					Debug.Log(this.gameObject + " " + SWhit.collider.gameObject);
				}
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
				if (debug)
				{
					Debug.Log(this.gameObject + " " + NWhit.collider.gameObject);
				}
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
		if (debug)
		{
			Debug.Log(this.gameObject + " " + tempTarget + " " + tempTarget.transform.position);
		}

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

		if (debug)
		{
			Debug.Log(this.gameObject + " " + this.transform.position.y + " " + tempTarget.transform.position.y);
		}
		if (this.transform.position.y < target.transform.position.y)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position +" " + "top");
			}		
			topHalf = true;
		}
		else if (this.transform.position.y > target.transform.position.y)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position + " " + "bot");
			}
			bottomHalf = true;
		}
		else
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position + " " + "x");
			}
			sameX = true;
		}
		if (debug)
		{
			Debug.Log(this.gameObject + " " + this.transform.position.x + " " + tempTarget.transform.position.x);
		}
		if (this.transform.position.x < target.transform.position.x)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position + " " + "rig");
			}
			rightHalf = true;
		}
		else if (this.transform.position.x > target.transform.position.x)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position + " " + "lef");
			}
			leftHalf = true;
		}
		else
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + this.transform.position + " " + "y");
			}
			sameY = true;
		}

		if ((topHalf || sameX) && rightHalf)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + "1 " + topHalf + bottomHalf + sameX + rightHalf + leftHalf + sameY);
			}
			//1st priority
			if (rayDirection(direction.NE) == true)
			{
				if (debug)
				{
					Debug.Log(this.gameObject + " " + "NE true");
				}
				return true;
			}
			//2nd priority
			else if (rayDirection(direction.SE) == true)
			{
				if (debug)
				{
					Debug.Log(this.gameObject + " " + "SE true");
				}
				return true;
			}
			//3th priority
			else if (rayDirection(direction.NW) == true)
			{
				return true;
			}
			//4th priority
			else if (rayDirection(direction.SW) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (topHalf && (leftHalf || sameY))
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + "2 " + topHalf + bottomHalf + sameX + rightHalf + leftHalf + sameY);
			}
			//1st priority
			if (rayDirection(direction.NW) == true)
			{
				return true;
			}
			//2nd priority
			else if (rayDirection(direction.NE) == true)
			{
				return true;
			}
			//3rd priority
			else if (rayDirection(direction.SW) == true)
			{
				return true;
			}
			//4th priority
			else if (rayDirection(direction.SE) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (bottomHalf && (rightHalf || sameY))
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + "3 " + topHalf + bottomHalf + sameX + rightHalf + leftHalf + sameY);
			}
			//1st priority
			if (rayDirection(direction.SE) == true)
			{
				return true;
			}
			//2nd priority
			else if (rayDirection(direction.SW) == true)
			{
				return true;
			}
			//3rd priority
			else if (rayDirection(direction.NE) == true)
			{
				return true;
			}
			//4th priority
			else if (rayDirection(direction.NW) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if ((bottomHalf || sameX) && leftHalf)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + "4 " + topHalf + bottomHalf + sameX + rightHalf + leftHalf + sameY);
			}
			//1st priority
			if (rayDirection(direction.SW) == true)
			{
				return true;
			}
			//2nd priority
			else if (rayDirection(direction.NW) == true)
			{
				return true;
			}
			//3rd priority
			else if (rayDirection(direction.SE) == true)
			{
				return true;
			}
			//4th priority
			else if (rayDirection(direction.NE) == true)
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
			return false;
		}
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
			if (NEChecked == false)
			{
				NEChecked = true;
				tempTile = getAdjacentTiles(direction.NE).GetComponent<pathNodes>();
			}
			else
			{
				return false;
			}
		}
		else if (tempDirect == direction.SE)
		{
			if (SEChecked == false)
			{
				SEChecked = true;
				tempTile = getAdjacentTiles(direction.SE).GetComponent<pathNodes>();
			}
			else
			{
				return false;
			}
		}
		else if (tempDirect == direction.SW)
		{
			if (SWChecked == false)
			{
				SWChecked = true;
				tempTile = getAdjacentTiles(direction.SW).GetComponent<pathNodes>();
			}
			else
			{
				return false;
			}
		}
		else if (tempDirect == direction.NW)
		{
			if (NWChecked == false)
			{
				NWChecked = true;
				tempTile = getAdjacentTiles(direction.NW).GetComponent<pathNodes>();
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
		//remove blank tiles and wall tiles
		if (!tempTile || tempTile.Wall == true)
		{
			if (debug)
			{
				Debug.Log(this.gameObject + " " + "wall");
			}
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