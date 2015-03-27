using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveData : MonoBehaviour {

	private PlayerData player;
	[HideInInspector] public int waveNum = -1;
	public List<GameObject> starts;
	public GameObject button;
	//wave infomation
	private bool started = false;
	public float creepTimer;
	[HideInInspector] public int spawnedCreeps;
	[HideInInspector] public int deadCreeps;
	private float curTime;
	public float waveWaitTime;
	private bool wait = false;
 	//basic creep stats
	public GameObject basicCreep;
	public List<int> BasicCreepCount;
	public GameObject CancerCreep;
	public List<int> CancerCreepCount;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Game Data").GetComponent<PlayerData>();
		foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
		{
			if (tile.name == "start")
			{
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
		if (waveNum >= 0 && waveNum > BasicCreepCount.Count)
		{
			if (wait == false)
			{
				if (spawnedCreeps == deadCreeps * 0.8f)
				{
					curTime = Time.time;
					wait = true;
					button.SetActive(true);
				}
			}	
			if (wait == true && Time.time - curTime >= waveWaitTime)
			{
				wait = false;
				NextWave();
			}
		}
		else if (waveNum == BasicCreepCount.Count)
		{
			if (spawnedCreeps == deadCreeps)
				{
					player.victory();
				}
		}
	
	}
	
	public void NextWave()
	{
		button.SetActive(false);
		waveNum++;
		foreach (var tile in starts)
		{
			tile.GetComponent<startNode>().startPath();
			tile.GetComponent<creepSpawn>().BasicCreepCount += BasicCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().CancerCreepCount += CancerCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().NextCreep();
		}
			
	}
}
