using UnityEngine;
using System.Collections;

public class pathfindTest : MonoBehaviour {

	public boardTiles board;
	public startNode start;
	public endNode finish;

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
			Debug.Log("start path");
			start.startPath();
		}
	}
}
