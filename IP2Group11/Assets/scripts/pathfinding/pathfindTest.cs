using UnityEngine;
using System.Collections;

public class pathfindTest : MonoBehaviour {

	public boardTiles board;
	public startNode start;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10,10,150.0f,150.0f),"start path"))
		{
			Debug.Log("start walls");
			board.detectWalls();
			Debug.Log("start path");
			start.startPath();
		}
		if (GUI.Button(new Rect(10, 160, 150.0f, 150.0f), "start detect"))
		{
			Debug.Log("start walls");
			board.detectWalls();
		}
	}
}
