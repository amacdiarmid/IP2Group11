﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creepMovement : MonoBehaviour {

	public List<Vector2> path = new List<Vector2>();
	private bool go;
	public int i;
	[Range(0,10)] public float speed;
	private Vector3 movement;
	public int HP;
	public PlayerData playerData;

	// Use this for initialization
	void Start () {
		playerData = GameObject.Find("Game Data").GetComponent<PlayerData>();
		movement = new Vector3(2, 1.2f, 0) / speed;
		i++;
		path = GameObject.Find("finish").GetComponent<endNode>().path;
		go = true;
		float a = path[i].x - path[i - 1].x;
		float b = path[i].y - path[i - 1].y;
	}
	
	// Update is called once per frame
	void Update () {
		if (go == true)
		{
			//"up" is NE
			//"down" is SW
			//"left" is NW
			//"right" is SE
			// movement conditions
			//decide direction to move
			if (path[i].x - path[i - 1].x >= 2)
			{
				//decided to go E
				if (path[i].y - path[i - 1].y <= -1)
				{
					//decided to go SE
					if (this.transform.position.x > path[i].x && this.transform.position.y < path[i].y)
					{
						i++;
					}
					else
					{
						//move right
						moveRight();
					}
				}
				else if (path[i].y - path[i - 1].y >= 1)
				{
					//decided to go NE
					if (this.transform.position.x > path[i].x && this.transform.position.y > path[i].y)
					{
						i++;
					}
					else
					{
						//move up
						moveUp();
					}
				}
				else
				{
					float a = path[i].x - path[i - 1].x;
					float b = path[i].y - path[i - 1].y;
				}
			}
			else if (path[i].x - path[i - 1].x <= -2)
			{
				//decided to go W
				if (path[i].y - path[i - 1].y >= 1)
				{
					//decided to go NW
					if (this.transform.position.x < path[i].x && this.transform.position.y > path[i].y)
					{
						i++;
					}
					else
					{
						//move left
						moveLeft();
					}
				}
				else if (path[i].y - path[i - 1].y <= -1)
				{
					//decided to go SW
					if (this.transform.position.x < path[i].x && this.transform.position.y < path[i].y)
					{
						i++;
					}
					else
					{
						//move down
						moveDown();
					}
				}
				else
				{
					float a = path[i].x - path[i - 1].x;
					float b = path[i].y - path[i - 1].y;
				}
				
			}
			else
			{
				float a = path[i].x - path[i - 1].x;
				float b =  path[i].y - path[i - 1].y;
			}
			if (i == path.Count)
			{
				playerData.RemoveHealth(1);
				Destroy(this.gameObject);
				//remove life from total count
			}
		}
	}

	void moveUp()
	{
		movement = new Vector3(2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveDown()
	{
		movement = new Vector3(-2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveLeft()
	{
		movement = new Vector3(-2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveRight()
	{
		movement = new Vector3(2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}
}
