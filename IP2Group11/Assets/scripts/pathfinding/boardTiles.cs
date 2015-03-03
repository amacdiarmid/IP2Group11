using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	public startNode start;
	public List<pathNodes> tileNodes;
	public List<spawnTower> tileSpawns;

	// Use this for initialization
	void Start () 
	{
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

	public void startPath()
	{
		start.startPath();
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
}
