using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	private boardTiles board;

	// Use this for initialization
	void Start () 
	{
		end = GameObject.Find("board/finish").GetComponent<endNode>();
		board = GameObject.Find("board").GetComponent<boardTiles>();
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		startPath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool startPath()
	{
		done = false;
		board.clearDirections();
		if (recieveRay() == true)
		{
			Debug.Log("start path = true");
			return true;
		}
		else
		{
			Debug.Log("start path = false");
			return false;
		}
	}
}
