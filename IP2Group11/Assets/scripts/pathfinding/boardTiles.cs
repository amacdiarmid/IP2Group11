using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	public startNode start;
	public List<pathNodes> tiles;

	// Use this for initialization
	void Start () 
	{
		tiles.Clear();
		foreach(GameObject tile in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (tile.tag == "Tile")
			{
				tiles.Add(tile.GetComponent<pathNodes>());
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
}
