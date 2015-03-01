using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveData : MonoBehaviour {

	private int waveNum = -1;
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
		if (basicCreepCounter > 0)
		{
			Instantiate(basicCreep, start.transform.position, Quaternion.identity);
			basicCreepCounter--;
			StartCoroutine("Wait");
		}	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(CreepTimer);
		NextCreep();
	}
}
