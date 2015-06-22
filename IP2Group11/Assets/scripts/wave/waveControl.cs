using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class waveControl : MonoBehaviour {

	[HideInInspector] public int totalCreeps;
	[HideInInspector] public int curWave = 0;
	[HideInInspector] public bool victoryCheck;
	public int totalWaves;
	public List<spawnPoint> spawns;
	private PlayerData buttonCon;
	public Button nextWaveBut;
	public List<AudioClip> sounds;

	// Use this for initialization
	void Start () {
		buttonCon = GameObject.Find("Game Data").GetComponent<PlayerData>();
		nextWaveBut.gameObject.SetActive(true);
		victoryCheck = false;
		totalCreeps = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (victoryCheck == true)
		{
			Debug.Log(totalCreeps);
			if (totalCreeps == 0)
			{
				buttonCon.victory();
				this.GetComponent<AudioSource>().clip = sounds[1];
				this.GetComponent<AudioSource>().Play();
			}
		}
	}

	public void nextWave()
	{
		this.GetComponent<AudioSource>().clip = sounds[0];
		this.GetComponent<AudioSource>().Play();
		nextWaveBut.gameObject.SetActive(false);
		curWave++;
		foreach (var spawn in spawns)
		{
			spawn.gameObject.GetComponent<startNode>().startPath();
			spawn.StartCoroutine("nextWave");
		}
	}

	public void checkDone()
	{
		foreach (var spawn in spawns)
		{
			if (spawn.done == false)
			{
				return;
			}
		}
		if (curWave == totalWaves)
		{
			Debug.Log("victory check");
			victoryCheck = true;
		}
		else
		{
			nextWaveBut.gameObject.SetActive(true);
			this.GetComponent<AudioSource>().clip = sounds[1];
			this.GetComponent<AudioSource>().Play();
		}
	}
}
