using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class heroMovement : MonoBehaviour {

	private Vector3 currentPos;
	private Vector3 posToMove;
	private bool selected = false;
	private boardTiles board;
	[Range(0, 10)] public float speed;
	public bool move;
	private Vector3 movement;
	private float distance;
	private float startTime;
	private Animator animator;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 99;
		board = GameObject.Find("board").GetComponent<boardTiles>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / distance;
			transform.position = Vector3.Lerp(currentPos, posToMove, fracJourney);
			if (fracJourney >= 1)
			{
				animator.SetTrigger("idle");
				transform.localScale = new Vector3(1, 1, 1);
				move = false;
			}
		}
		if (Input.GetButtonUp("move"))
		{
			animator.SetTrigger("selected");
			Debug.Log("hero selected 1");
			Select();
		}
		
	}

	public void moveHero(Vector3 heroMovePos)
	{		
		currentPos = transform.position;
		posToMove = heroMovePos;
		if (currentPos.x > posToMove.x && currentPos.y < posToMove.y)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (currentPos.x < posToMove.x && currentPos.y < posToMove.y)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (currentPos.x < posToMove.x && currentPos.y > posToMove.y)
		{
			transform.localScale = new Vector3(-1, -1, 1);
		}
		else if (currentPos.x > posToMove.x && currentPos.y > posToMove.y)
		{
			transform.localScale = new Vector3(1, -1, 1);
		}
		else
		{
			Debug.Log("movement gone wrong");
		}
		distance = Vector3.Distance(currentPos, posToMove);
		startTime = Time.time;
		move = true;
		selected = false;
		board.heroSelected = false;
		animator.SetTrigger("move");
	}

	public void Select()
	{
		if (selected == true)
		{
			Debug.Log("hero selected 2");
			selected = false;
			board.heroSelected = false;
		}
		else
		{
			Debug.Log("hero selected 3");
			selected = true;
			board.heroSelected = true;
		}
	}
}
