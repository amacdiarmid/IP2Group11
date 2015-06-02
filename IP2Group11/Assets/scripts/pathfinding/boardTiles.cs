using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	//variable for the start node(where the creeps spawn and where the path must start from)
	[HideInInspector] public startNode start;
	//list containing each of the 2 scripts attatched to each tile
	[HideInInspector] public List<pathNodes> tileNodes;
	[HideInInspector] public List<spawnTower> tileSpawns;
	//the hero on the board and where they are selected to be moved
	[HideInInspector] public bool heroSelected;
	[HideInInspector] public heroMovement hero;
	//the object that controls the camera movement
	private cameraMovement camMove;
	Vector2 minBounds;
	Vector2 maxBounds;

	// Use this for initialization
	void Start () 
	{
		//set the hero and the camMove object
		hero = GameObject.Find("hero").GetComponent<heroMovement>();
		camMove = GameObject.Find("Main Camera").GetComponent<cameraMovement>();
		//remove eveything from the list to then add all the tiles to the list
		tileNodes.Clear();
		foreach(GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
		{
			//for every tile add to this list
			tileNodes.Add(tile.GetComponent<pathNodes>());
			if (tile.name == "grass")
			{
				//if the tile can be build on then add to this list as well
				tileSpawns.Add(tile.GetComponent<spawnTower>());
			}
			else if (tile.name == "start")
			{
				start = tile.GetComponent<startNode>();
			}
			//check to see if that is a corner tile
			if (tile.transform.position.x > maxBounds.x)
			{
				maxBounds.x = tile.transform.position.x;
			}
			else if (tile.transform.position.x < minBounds.x)
			{
				minBounds.x = tile.transform.position.x;
			}
			if (tile.transform.position.y > maxBounds.y)
			{
				maxBounds.y = tile.transform.position.y;
			}
			else if (tile.transform.position.y < minBounds.y)
			{
				minBounds.y = tile.transform.position.y;
			}
		}
		camMove.maxBound = maxBounds;
		camMove.minBound = minBounds;
	}
	/// <summary>
	/// used to reset the infomation from the previous path find for all the tiles
	/// </summary>
	public void clearDirections()
	{
		foreach (var tile in tileNodes)
		{
			//for every tile reset its search directions to unserched (true)
			tile.NEChecked = false;
			tile.SWChecked = false;
			tile.NWChecked = false;
			tile.SEChecked = false;
		}
	}
	/// <summary>
	/// this is called when a new location for the hero to move is needed 
	/// the paramiter is the new location
	/// this sets the heros new postion to the paramiter
	/// </summary>
	/// <param name="heroMovePos"></param>
	public void sendNewPos(Vector3 heroMovePos)
	{
		hero.moveHero(heroMovePos);
	}
}
