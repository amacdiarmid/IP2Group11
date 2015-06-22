using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnPoint : MonoBehaviour {

	[HideInInspector] public bool done;
	public List<waveInfo> waves;
	private int curWave = -1;
	private waveControl waveCon;

	// Use this for initialization
	void Start () 
	{
		waveCon = GameObject.Find("Game Data").GetComponent<waveControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator nextWave()
	{
		done = false;
		curWave++;
		for (int i = 0; i < waves[curWave].creeps.Count; i++)
		{
			GameObject tempCreep = Instantiate(waves[curWave].creeps[i], this.transform.position, Quaternion.identity) as GameObject;
			tempCreep.GetComponent<creepMovement>().addPath(this.gameObject.GetComponent<startNode>().comPath);
			waveCon.totalCreeps++;
			yield return new WaitForSeconds(waves[curWave].time[i]);
		}
		done = true;
		waveCon.checkDone();
	}
}
