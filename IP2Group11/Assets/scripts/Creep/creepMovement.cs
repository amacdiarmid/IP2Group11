using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creepMovement : MonoBehaviour {

	public List<Vector2> path = new List<Vector2>();
	private bool go;
	public int postion;
	[Range(0,10)] public float speed;
	public int HP;
	private PlayerData player;
	public int value;
	public int goldGain;
	private waveControl wave;
	public AudioClip[] sounds;
	private float startTime;
	private float distance;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Game Data").GetComponent<PlayerData>();
		wave = GameObject.Find("Game Data").GetComponent<waveControl>();
		Physics2D.IgnoreLayerCollision(8, 9);
		Physics2D.IgnoreLayerCollision(9, 10);
		startTime = Time.time;
		postion = 0;
	}

	public void addPath(List<GameObject> tempPath)
	{
		foreach (var item in tempPath)
		{
			path.Add(item.transform.position);
		}
		distance = Vector3.Distance(path[postion], path[postion + 1]);
		go = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y + 10;
		
		if (go == true && postion < path.Count)
		{	
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / distance;
			transform.position = Vector3.Lerp(path[postion], path[postion + 1], fracJourney);
			if (fracJourney >= 1.0f)
			{
				postion++;
				if (postion + 1 == path.Count)
				{
					Debug.Log("destroy creep");
					wave.totalCreeps--;
					player.RemoveHealth(value);
					Destroy(this.gameObject);
				}
				else
				{
					distance = Vector3.Distance(path[postion], path[postion + 1]);	
					startTime = Time.time;
				}	
			}		
		}
	}

	public void removeHealth(int damage)
	{
		HP -= damage;
		materialChange();
		if (HP <= 0)
		{
			GetComponent<AudioSource>().clip = sounds[0];
			wave.totalCreeps--;
			player.AddGold(goldGain);
			GetComponent<AudioSource>().Play ();
			float clipLength = (float) GetComponent<AudioSource>().clip.length;
			Wait (clipLength);
			Destroy(this.gameObject);
		}
	}

	IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds(time);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}

	public void materialChange()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.red;
		StartCoroutine (Wait (0.1f));
	}
}
