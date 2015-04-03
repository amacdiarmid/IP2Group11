using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	//variable for the start node(where the creeps spawn and where the path must start from)
	public startNode start;
	//list containing each of the 2 scripts attatched to each tile
	public List<pathNodes> tileNodes;
	public List<spawnTower> tileSpawns;
	//the hero on the board and where they are selected to be moved
	[HideInInspector] public bool heroSelected;
	[HideInInspector] public heroMovement hero;
	//the gameobject that contais the tower info
	private towerData towers;

	// Use this for initialization
	void Start () 
	{
		//set the hero and the towerData object
		hero = GameObject.Find("hero").GetComponent<heroMovement>();
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
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
		}
	}
	/// <summary>
	/// used to reset the infomation from the previous path find for all the tiles
	/// </summary>
	public void clearDirections()
	{
		foreach (var tile in tileNodes)
		{
			//for every tile reset its search directions to unserched (true)
			tile.Up = true;
			tile.Down = true;
			tile.Left = true;
			tile.Right = true;
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
