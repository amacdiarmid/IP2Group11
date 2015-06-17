using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class endNode : pathNodes {
	
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		//set all the checked directions to true(they arent needed as this is the finish but it is good to keep them true)
		NEChecked = false;
		SWChecked = false;
		NWChecked = false;
		SEChecked = false;
		sprite.sortingOrder = -(int)this.gameObject.transform.position.y;
	}
	/// <summary>
	/// called whenever this tile has been hit by a raycast sent from another tile
	/// the "recieved ray" is what im calling the the part where all the mathods return true as is cascades backward througth the path
	/// </summary>
	/// <returns>this will return true and send the "recieved ray" back througth all the ties</returns>
	public override bool recieveRay(List<GameObject> tempPath, GameObject tempTarget, direction tempDirect)
	{
		if (tempTarget == this.gameObject)
		{
			//add the postion to the array
			tempPath.Add(this.gameObject);
			//remove any duplicates in the list
			tempPath = tempPath.Distinct().ToList();
			return true;
		}
		else
		{
			return false;
		}
	}
}
