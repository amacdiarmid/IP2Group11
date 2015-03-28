using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class heroMovement : MonoBehaviour {

	private Vector3 currentPos;
	private Vector3 posToMove;
	private bool selected;
	private boardTiles board;
	[Range(0, 10)] public float speed;
	public bool move;
	private Vector3 movement;
	private float distance;
	private float startTime;

	// Use this for initialization
	void Start () {
		board = GameObject.Find("board").GetComponent<boardTiles>();
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / distance;
			transform.position = Vector3.Lerp(currentPos, posToMove, fracJourney);
		}
		if (Input.GetKeyUp("move"))
		{
			Select();
		}
		
	}

	public void moveHero(Vector3 heroMovePos)
	{		
		currentPos = transform.position;
		posToMove = heroMovePos;
		distance = Vector3.Distance(currentPos, posToMove);
		startTime = Time.time;
		move = true;
		selected = false;
		board.heroSelected = false;
	}

	public void Select()
	{
		if (selected == true)
		{
			selected = false;
		}
		else
		{
			selected = true;
		}
	}
}
