using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveData : MonoBehaviour {

	//the player data object
	private PlayerData player;
	//the current wave variable(used in the lists so it need to be -ve 1)
	[HideInInspector] public int waveNum = -1;
	//the actual current wave(could have used [curWave -1] in the lists and eliminated the use of the waveNum variable)
	[HideInInspector] public int curWave = 0;
	//list containing all the spawn areas on the board( is a list as i was prepating to have multiple start zones)
	public List<GameObject> starts;
	//buttonf to call the next wave
	public GameObject button;
	
	//wave infomation variables
	private bool started = false;
	// creep timer depending on how long between each creep spawn
	public float creepTimer;
	// ints holding how many creeps have spawned and how many have been killed
	[HideInInspector] public int spawnedCreeps;
	[HideInInspector] public int deadCreeps;
	//the current game time
	private float curTime;
	//timer between each wave
	public float waveWaitTime;
	//bool to see if the waiting has been done between waves
	private bool wait = false;

 	//basic creep stats
	//basic creep prefab and how many spawn each wave
	public GameObject basicCreep;
	public List<int> BasicCreepCount;
	//cancer creep prefab and how many spawn each wave
	public GameObject CancerCreep;
	public List<int> CancerCreepCount;
	public AudioClip[] sounds;

	// Use this for initialization
	void Start () 
	{
		//find the player data and then loop througth the list of every tile and find start(s)
		player = GameObject.Find("Game Data").GetComponent<PlayerData>();
		foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
		{
			if (tile.name == "start")
			{
				//foe each start found set the creep timer and prefabs.
				Debug.Log(tile.name);
				starts.Add(tile);
				tile.GetComponent<creepSpawn>().creepTimer = creepTimer;
				tile.GetComponent<creepSpawn>().basicCreep = basicCreep;
				tile.GetComponent<creepSpawn>().CancerCreep = CancerCreep;
				tile.GetComponent<creepSpawn>().data = this;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(waveNum +" " +BasicCreepCount.Count +" wave check");
		if (waveNum >= 0 && waveNum < BasicCreepCount.Count)
		{
			//if the first wave has been called and has not reached the final wave
			Debug.Log("1 loop check");
			if (wait == false)
			{
				//if you are not waiting for the wave timer to finish
				Debug.Log("2 loop check" + deadCreeps + " " + spawnedCreeps);
				if (deadCreeps >= spawnedCreeps * 0.8f)
				{
					//if 80% of the spawned creeps are dead then you can start the next wave
					Debug.Log("3 loop check");
					curTime = Time.time;
					//begin waiting
					wait = true;
					button.SetActive(true);
				}
			}	
			if (wait == true && Time.time - curTime >= waveWaitTime)
			{
				//if the waiting has started and the game time has gone over the wait time then start the next wave
				Debug.Log("4 loop check");
				wait = false;
				NextWave();
			}
		}
		else if (waveNum == BasicCreepCount.Count)
		{
			//if you reach the final wave
			Debug.Log("5 loop check");
			if (deadCreeps == spawnedCreeps)
				{
					//and all the creeps are dead then you win
					player.victory();
				}
		}
	
	}
	/// <summary>
	/// called from OnClick even from next wave button
	/// called after the game time has gone over the wait time
	/// </summary>
	public void NextWave()
	{
		audio.clip = sounds[0];
		audio.Play();
		//hide the next wave button and increase the wave
		button.SetActive(false);
		waveNum++;
		curWave++;
		foreach (var tile in starts)
		{
			//start the pathfinding 
			tile.GetComponent<startNode>().startPath();
			//increace the amout of creeps to be spawned in each of the start tiles
			//divide the creeps so they are split between all the tiles
			tile.GetComponent<creepSpawn>().BasicCreepCount += BasicCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().CancerCreepCount += CancerCreepCount[waveNum] / starts.Count;
			//then start spawning them
			tile.GetComponent<creepSpawn>().NextCreep();
		}
			
	}
}
