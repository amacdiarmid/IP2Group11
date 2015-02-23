using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creepMovement : MonoBehaviour {

	public List<Vector2> path = new List<Vector2>();
	public float tolerance;
	private bool go;
	public int i;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (go == true)
		{
			// movement conditions
			//decide direction to move
			if (path[i].y - path[i - 1].y == 0)
			{
				//move left/right
				if (path[i].x - path[i - 1].x > path[i].y - path[i - 1].y)
				{
					if (this.transform.position.x > path[i].x)
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
				else if (path[i].x - path[i - 1].x < path[i].y - path[i - 1].y)
				{
					if (this.transform.position.x < path[i].x)
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
				else
				{
					Debug.Log("not moving left/right");
				}
			}
			else if (path[i].x - path[i - 1].x == 0)
			{
				//move up/down
				if (path[i].y - path[i - 1].y > path[i].x - path[i - 1].x)
				{
					if (this.transform.position.y > path[i].y)
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
				else if (path[i].y - path[i - 1].y < path[i].x - path[i - 1].x)
				{
					if (this.transform.position.y < path[i].y)
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
					Debug.Log("not moving up/down");
				}
			}	
			else
			{
				Debug.Log("not moving anywhere");
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
		if (renderer.bounds.size.x > renderer.bounds.size.y)
		{
			tolerance = Random.RandomRange(0, 0.5f - (renderer.bounds.size.x/2));
		}
		else
		{
			tolerance = Random.RandomRange(0, 0.5f - (renderer.bounds.size.y/2));
		}
		go = true;
	}

	void moveUp()
	{
		Debug.Log("move up");
		transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
	}

	void moveDown()
	{
		Debug.Log("move down");
		transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime, Space.World);
	}

	void moveLeft()
	{
		Debug.Log("move left");
		transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime, Space.World);
	}

	void moveRight()
	{
		Debug.Log("move right");
		transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
	}
}
