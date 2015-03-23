using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class waveData : MonoBehaviour {

	private int waveNum = -1;
	public List<GameObject> starts;
	public GameObject button;
	//wave infomation
	private bool started = false;
	public float creepTimer;
	[HideInInspector] public int spawnedCreeps;
	private float curTime;
	public float waveWaitTime;
	private bool wait = false;
 	//basic creep stats
	public GameObject basicCreep;
	public List<int> BasicCreepCount;
	public GameObject CancerCreep;
	public List<int> CancerCreepCount;
	public GameObject LocustCreep;
	public List<int> LocustCreepCount;	

	// Use this for initialization
	void Start () 
	{
		foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
		{
			if (tile.name == "start")
			{
				Debug.Log(tile.name);
				starts.Add(tile);
				tile.GetComponent<creepSpawn>().creepTimer = creepTimer;
				tile.GetComponent<creepSpawn>().basicCreep = basicCreep;
				tile.GetComponent<creepSpawn>().data = this;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waveNum >= 0)
		{
			if (wait == false)
			{
				if (spawnedCreeps == BasicCreepCount[waveNum] + CancerCreepCount[waveNum] + LocustCreepCount[waveNum])
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
	}
	
	public void NextWave()
	{
		spawnedCreeps = 0;
		button.SetActive(false);
		waveNum++;
		foreach (var tile in starts)
		{
			tile.GetComponent<startNode>().startPath();
			tile.GetComponent<creepSpawn>().BasicCreepCount += BasicCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().CancerCreepCount += CancerCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().LocustCreepCount += LocustCreepCount[waveNum] / starts.Count;
			tile.GetComponent<creepSpawn>().NextCreep();
		}
			
	}
}
