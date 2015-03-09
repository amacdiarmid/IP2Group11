using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	private boardTiles board;
	private towerData towers;
	private heroMovement hero;

	// Use this for initialization
	void Start () 
	{
		end = GameObject.Find("board/finish").GetComponent<endNode>();
		board = GameObject.Find("board").GetComponent<boardTiles>();
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
		hero = GameObject.Find("hero").GetComponent<heroMovement>();
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
		towers.hideCollider();
		hero.HideCollider();
		if (recieveRay() == true)
		{
			towers.hideCollider();
			hero.HideCollider();
			return true;
		}
		else
		{
			towers.hideCollider();
			hero.HideCollider();
			return false;
		}
	}
}
