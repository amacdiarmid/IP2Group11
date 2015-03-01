using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveData : MonoBehaviour {

	private int waveNum = -1;
	private bool spawnCreep = true;
	public startNode start;
	public float CreepTimer;
	public GameObject basicCreep;
	public List<int> BasicCreepCount;
	private int basicCreepCounter;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void NextWave()
	{
		start.startPath();
		waveNum++;
		basicCreepCounter =+ BasicCreepCount[waveNum];
		NextCreep();
	}

	public void NextCreep()
	{
		if (basicCreepCounter > 0 && spawnCreep == true)
		{
			Instantiate(basicCreep, start.transform.position, Quaternion.identity);
			basicCreepCounter--;
			StartCoroutine("Wait");
		}	
	}

	IEnumerator Wait()
	{
		spawnCreep = false;
		yield return new WaitForSeconds(CreepTimer);
		spawnCreep = true;
		NextCreep();
	}
}
