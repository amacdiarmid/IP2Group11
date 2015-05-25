using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	//contains inherited variables as well
	//varibles that contain the board infomation, tower infomation and the hero
	private boardTiles board;
	private towerData towers;

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		//set the varibles to the correct objects 
		end = GameObject.Find("board/finish").GetComponent<endNode>();
		board = GameObject.Find("board").GetComponent<boardTiles>();
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
		//set the checked directions to unchecked (true)
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		//start the inital pathfind
		startPath();
	}

	/// <summary>
	/// called from the start, built tower and new wave
	/// starts the pathfinding off
	/// </summary>
	/// <returns>returns true when there is a confirmed path</returns>
	public bool startPath()
	{
		//resets the done variable to false so the pathfinding will work
		done = false;
		//removes old corords from previous pathfinds
		board.clearDirections();
		//hides the colliders for the towers on the board
		towers.hideCollider();
		if (recieveRay() == true)
		{
			//if the return ray is true then there is a found path and can return true.
			//and the colliders can return to the towers
			towers.hideCollider();
			return true;
		}
		else
		{
			//if the return ray is false then there is no found path and can return false.
			//and the colliders can return to the towers
			towers.hideCollider();
			return false;
		}
	}
}
