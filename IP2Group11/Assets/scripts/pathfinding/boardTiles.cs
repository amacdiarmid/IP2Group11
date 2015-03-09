using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	public startNode start;
	public List<pathNodes> tileNodes;
	public List<spawnTower> tileSpawns;
	[HideInInspector] public bool heroSelected;
	[HideInInspector] public heroMovement hero;
	private towerData towers;

	// Use this for initialization
	void Start () 
	{
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
		tileNodes.Clear();
		foreach(GameObject tile in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (tile.tag == "Tile")
			{
				tileNodes.Add(tile.GetComponent<pathNodes>());
				if (tile.name == "grass")
				{
					tileSpawns.Add(tile.GetComponent<spawnTower>());
				}	
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clearDirections()
	{
		foreach (var tile in tileNodes)
		{
			tile.Up = true;
			tile.Down = true;
			tile.Left = true;
			tile.Right = true;
		}
	}

	public void sendNewPos(Vector3 heroMovePos)
	{
		hero.moveHero(heroMovePos);
	}
}
