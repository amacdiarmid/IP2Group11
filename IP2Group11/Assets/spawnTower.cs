﻿using UnityEngine;
using System.Collections;

public class spawnTower : MonoBehaviour {

	private bool mouseOver;
	private bool mouseDown;
	private towerData towerData;
	private pathNodes Node;
	private bool wall;
	private Canvas canvas;
	private GameObject tower;
	private bool UIActive;

	// Use this for initialization
	void Start () 
	{
		Node = this.GetComponent<pathNodes>();
		towerData = GameObject.Find("Game Data").GetComponent<towerData>();
		canvas = this.gameObject.GetComponentInChildren<Canvas>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if (towerData.UIActive == false)
		{
			if (UIActive == false)
			{
				towerData.UIActive = true;
				canvas.enabled = true;
				UIActive = true;
			}
		}
		else if (towerData.UIActive == true && UIActive == true)
		{
			towerData.UIActive = false;
			canvas.enabled = false;
			UIActive = false;
		}
	}

	public void spawnWall()
	{
		if (wall == false)
		{
			Node.Wall = true;
			wall = true;
			tower = Instantiate(towerData.wall, this.transform.position, Quaternion.identity) as GameObject;
			tower.transform.parent = transform;
			towerData.UIActive = false;
			canvas.enabled = false;
			UIActive = false;
		}
	}

	public void destroyWall()
	{
		Node.Wall = false;
		wall = false;
		towerData.UIActive = false;
		canvas.enabled = false;
		UIActive = false;
		Destroy(tower);
	}
}