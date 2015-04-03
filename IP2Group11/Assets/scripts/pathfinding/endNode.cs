using UnityEngine;
using System.Collections;
using System.Linq;

public class endNode : pathNodes {

	//the board object containing info on all the tiles
	public boardTiles board;

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		//set the board object in the variables
		board = GameObject.Find("board").GetComponent<boardTiles>();
		//set all the checked directions to true(they arent needed as this is the finish but it is good to keep them true)
		Up = true;
		Down = true;
		Left = true;
		Right = true;
	}
	/// <summary>
	/// called whenever this tile has been hit by a raycast sent from another tile
	/// the "recieved ray" is what im calling the the part where all the mathods return true as is cascades backward througth the path
	/// </summary>
	/// <returns>this will return true and send the "recieved ray" back througth all the ties</returns>
	public override bool recieveRay()
	{
		if (done == false)
		{
			//sets the done varible to fals to stop any other raycast out there searching 
			done = true;
			//add the postion to the array
			path.Add(this.transform.position);
			//remove any duplicates in the list
			path = path.Distinct().ToList();
			return true;
		}
		else
		{
			//this was a condition if there was a problem
			return false;	
		} 
	}
}
