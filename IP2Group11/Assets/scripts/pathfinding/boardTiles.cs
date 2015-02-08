﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boardTiles : MonoBehaviour {

	public startNode start;
	public List<pathNodes> tiles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void detectWalls()
	{
		foreach (var tile in tiles)
		{
			tile.detectWall();
		}
		Debug.Log("done walls");
	}

	public void startPath()
	{
		start.startPath();
	}
}
