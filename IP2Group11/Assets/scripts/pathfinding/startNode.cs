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
	public Color tempColour;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		//set the sprite order in layer to -ve the y co-ordinate
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		sprite.sortingOrder = -(int)this.gameObject.transform.position.y;
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
			///*
			for (int i = 0; i < comPath.Count; i++)
			{
				for (int j = comPath.Count - 1; j > i + 3; j--)
				{
					if (comPath[i].GetComponent<pathNodes>().getAdjacentTiles(direction.NE) == comPath[j])
					{
						if (debug)
						{
							Debug.Log(i + " " + j + "removing " + (j - (i + 1)) + " points NE");
						}
						comPath.RemoveRange(i + 1, j - (i + 1));
					}
					else if (comPath[i].GetComponent<pathNodes>().getAdjacentTiles(direction.SE) == comPath[j])
					{
						if (debug)
						{
							Debug.Log(i + " " + j + "removing " + (j - (i + 1)) + " points SE");
						}
						comPath.RemoveRange(i + 1, j - (i + 1));
					}
					else if (comPath[i].GetComponent<pathNodes>().getAdjacentTiles(direction.SW) == comPath[j])
					{
						if (debug)
						{
							Debug.Log(i + " " + j + "removing " + (j - (i + 1)) + " points SW");
						}
						comPath.RemoveRange(i + 1, j - (i + 1));
					}
					else if (comPath[i].GetComponent<pathNodes>().getAdjacentTiles(direction.NW) == comPath[j])
					{
						if (debug)
						{
							Debug.Log(i + " " + j + "removing " + (j - (i + 1)) + " points NW");
						}
						comPath.RemoveRange(i + 1, j - (i + 1));
					}
					else
					{
						if (debug)
						{
							Debug.Log(i + " " + j);
						}
					}
					
				}
			}
			// * */
			/*
			foreach (var item in comPath)
			{
				item.GetComponent<Renderer>().material.color = tempColour;
			}
			 * */
			return true;
		}
		else
		{
			//if the return ray is false then there is no found path and can return false.
			//and the colliders can return to the towers
			Debug.Log("path error");
			comPath.Clear();
			foreach (var item in prevPath)
			{
				comPath.Add(item);
			}
			prevPath.Clear();
			return false;
		}
	}
}
