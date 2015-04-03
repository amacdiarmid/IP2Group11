using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creepMovement : MonoBehaviour {

	public List<Vector2> path = new List<Vector2>();
	private bool go;
	public int i;
	[Range(0,10)] public float speed;
	private Vector3 movement;
	public int HP;
	private PlayerData player;
	public int value;
	public int goldGain;
	private WaveData wave;
	public Color originalColor;
	public AudioClip[] sounds;

	// Use this for initialization
	void Start () {
		originalColor = gameObject.renderer.material.color;
		movement = new Vector3(2, 1.2f, 0) / speed;
		i++;
		foreach (var item in GameObject.Find("finish").GetComponent<endNode>().path)
		{
			path.Add(item);
		} 
		go = true;
		float a = path[i].x - path[i - 1].x;
		float b = path[i].y - path[i - 1].y;
		player = GameObject.Find("Game Data").GetComponent<PlayerData>();
		wave = GameObject.Find("Game Data").GetComponent<WaveData>();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
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
				wave.deadCreeps++;
				Destroy(this.gameObject);
				player.RemoveHealth(value);
			}
		}
	}

	void moveUp()
	{
		transform.localScale = new Vector3(-1, 1, 1);
		movement = new Vector3(2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveDown()
	{
		transform.localScale = new Vector3(1, 1, 1);
		movement = new Vector3(-2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveLeft()
	{
		transform.localScale = new Vector3(1, 1, 1);
		movement = new Vector3(-2, 1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	void moveRight()
	{
		transform.localScale = new Vector3(-1, 1, 1);
		movement = new Vector3(2, -1.2f, 0) / speed;
		transform.Translate(movement * Time.deltaTime, Space.World);
	}

	public void removeHealth(int damage)
	{
		HP -= damage;

		if (HP <= 0)
		{
			audio.clip = sounds[0];
			wave.deadCreeps++;
			player.AddGold(goldGain);
			audio.Play ();
			float clipLength = (float) audio.clip.length;
			Wait (clipLength);
			Destroy(this.gameObject);
		}
	}

	IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds(time);
		gameObject.renderer.material.color = originalColor;
	}

	public void materialChange()
	{

		gameObject.renderer.material.color = Color.red;
		StartCoroutine (Wait (0.1f));
	}
}
