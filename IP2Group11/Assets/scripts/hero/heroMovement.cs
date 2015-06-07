using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class heroMovement : MonoBehaviour {

	//the current position and the position to be moved to 
	private Vector3 currentPos;
	private Vector3 posToMove;
	//if the player is ready to be moved 
	private bool selected = false;
	//the object containing info about all the tiles
	private boardTiles board;
	//the heros speed limited by the range of 0-10
	[Range(0, 10)] public float speed;
	//if the player is moving or not
	[HideInInspector] public bool move;
	//used for moving the player 
	private Vector3 movement;
	private float distance;
	private float startTime;
	//the state machine for the animations of the player
	private Animator animator;

	// Use this for initialization
	void Start () {
		//set the sprite to a layer to 99 so it as above the boared but under the UI
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y + 40;
		//set the board object and the state machine
		board = GameObject.Find("board").GetComponent<boardTiles>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true)
		{
			//if the player is ready to be moved
			//using the speed gradually move the player from its current postion to the posToMove
			//using vector3.lerp
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / distance;
			transform.position = Vector3.Lerp(currentPos, posToMove, fracJourney);
			if (fracJourney >= 1)
			{
				//if the hero has reached its destination
				//set the animation to idle and the scale to default
				animator.SetTrigger("idle");
				transform.localScale = new Vector3(1, 1, 1);
				move = false;
			}
		}
		if (Input.GetButtonUp("Move"))
		{
			Select();
		}
		
	}
	/// <summary>
	/// this is called when a new location has been selected
	/// this will now figure out what direction it is moving and set the scale and animation
	/// </summary>
	/// <param name="heroMovePos"></param>
	public void moveHero(Vector3 heroMovePos)
	{		
		//set the currentPos to the current position
		currentPos = transform.position;
		//set the new postion to the paramiter pos
		posToMove = heroMovePos;
		//this will change the heros scale so the animation looks correct
		if (currentPos.x > posToMove.x && currentPos.y < posToMove.y)
		{
			//if the new position is less on the X and greater on the Y
			//run default animation
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (currentPos.x < posToMove.x && currentPos.y < posToMove.y)
		{
			//if the new position is greater on the X and greater on the Y
			//flip the sprite on is x-axis
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (currentPos.x < posToMove.x && currentPos.y > posToMove.y)
		{
			//if the new position is greater on the X and less on the Y
			//flip the sprite on is x-axis and y-axis
			transform.localScale = new Vector3(-1, -1, 1);
		}
		else if (currentPos.x > posToMove.x && currentPos.y > posToMove.y)
		{
			//if the new position is less on the X and less on the Y
			//flip the sprite on is y-axis
			transform.localScale = new Vector3(1, -1, 1);
		}
		else
		{
			//condition in case something goes wrong
			//Debug.Log("movement gone wrong");
		}
		//calculate the distance from the new and current pos
		distance = Vector3.Distance(currentPos, posToMove);
		//the current game time
		startTime = Time.time;
		//ready to move and selection are finished
		move = true;
		selected = false;
		board.heroSelected = false;
		//change animation state
		animator.SetTrigger("move");
	}
	/// <summary>
	/// called on the correct key press
	/// </summary>
	public void Select()
	{
		animator.SetTrigger("selected");
		if (selected == true)
		{
			//if the player is already selected unselect
			//Debug.Log("hero selected 2");
			selected = false;
			board.heroSelected = false;
		}
		else
		{
			//if the player isn't already selected select
			//Debug.Log("hero selected 3");
			selected = true;
			board.heroSelected = true;
		}
	}
}
