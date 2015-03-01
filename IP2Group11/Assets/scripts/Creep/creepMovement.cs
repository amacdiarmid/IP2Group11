using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creepMovement : MonoBehaviour {

	public List<Vector2> path = new List<Vector2>();
	//public float tolerance;
	private bool go;
	public int i;
	[Range(0,10)] public float speed;
	private Vector3 movement;
	public int HP;

	// Use this for initialization
	void Start () {
		movement = new Vector3(2, 1.2f, 0) / speed;
		Move();
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
						Debug.Log("next position");
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
						Debug.Log("next position");
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
					Debug.Log("not moving up/right " + a + " " + b);
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
						Debug.Log("next position");
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
						Debug.Log("next position");
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
					Debug.Log("not moving down/left " + a + " " + b);
				}
				
			}
			else
			{
				float a = path[i].x - path[i - 1].x;
				float b =  path[i].y - path[i - 1].y;
				Debug.Log("not moving anywhere " + a + " " + b);
			}
			if (i == path.Count)
			{
				Debug.Log("creep hit end");
				Destroy(this);
				//remove life from total count
			}
		}
	}

	//this will be moved to the start method so it will run when the creep has spawned
	public void Move()
	{
		i++;
		path = GameObject.Find("finish").GetComponent<endNode>().path;
		/*
		if (renderer.bounds.size.x > renderer.bounds.size.y)
		{
			tolerance = Random.RandomRange(0, 0.5f - (renderer.bounds.size.x/2));
		}
		else
		{
			tolerance = Random.RandomRange(0, 0.5f - (renderer.bounds.size.y/2));
		}
		*/
		go = true;
		float a = path[i].x - path[i - 1].x;
		float b = path[i].y - path[i - 1].y;
		Debug.Log("inital movement " + a + " " + b);
	}

	void moveUp()
	{
		Debug.Log("move up");
		movement = new Vector3(2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveDown()
	{
		Debug.Log("move down");
		movement = new Vector3(-2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveLeft()
	{
		Debug.Log("move left");
		movement = new Vector3(-2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveRight()
	{
		Debug.Log("move right");
		movement = new Vector3(2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}
}
