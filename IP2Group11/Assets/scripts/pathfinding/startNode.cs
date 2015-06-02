using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class startNode : pathNodes {

	//contains inherited variables as well
	//varibles that contain the board infomation, tower infomation and the hero
	private boardTiles board;
	public GameObject finish;
	public List<GameObject> comPath = new List<GameObject>();
	private List<GameObject> prevPath = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		//set the varibles to the correct objects 
		board = GameObject.Find("board").GetComponent<boardTiles>();
		//set the checked directions to unchecked (true)
		NEChecked = false;
		SWChecked = false;
		NWChecked = false;
		SEChecked = false;
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
		//removes old corords from previous pathfinds
		board.clearDirections();
		foreach (var item in comPath)
		{
			item.gameObject.GetComponent<Renderer>().material.color = Color.white;
			prevPath.Add(item);
		}
		comPath.Clear();
		//hides the colliders for the towers on the board
		if (recieveRay(comPath, finish, direction.none) == true)
		{
			//if the return ray is true then there is a found path and can return true.
			//and the colliders can return to the towers
			comPath.Reverse();
			prevPath.Clear();
			foreach (var item in comPath)
			{
				item.gameObject.GetComponent<Renderer>().material.color = Color.red;
			}
			return true;
		}
		else
		{
			//if the return ray is false then there is no found path and can return false.
			//and the colliders can return to the towers
			comPath.Clear();
			foreach (var item in prevPath)
			{
				item.gameObject.GetComponent<Renderer>().material.color = Color.red;
				comPath.Add(item);
			}
			prevPath.Clear();
			return false;
		}
	}
}
