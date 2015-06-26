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
	private AudioSource audioCom;

	// Use this for initialization
	void Start () {
		buttonCon = PlayerData.data;
		nextWaveBut.gameObject.SetActive(true);
		victoryCheck = false;
		totalCreeps = 0;
		audioCom = this.gameObject.GetComponent<AudioSource>();
		audioCom.volume = mouseClick.mouseCLK.volume / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (victoryCheck == true)
		{
			Debug.Log(totalCreeps);
			if (totalCreeps == 0)
			{
				buttonCon.victory();
				audioCom.volume = mouseClick.mouseCLK.volume / 100;
				audioCom.clip = sounds[1];
				audioCom.Play();
			}
		}
	}

	public void nextWave()
	{
		audioCom.volume = mouseClick.mouseCLK.volume / 100;
		audioCom.clip = sounds[0];
		audioCom.Play();
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
			audioCom.volume = mouseClick.mouseCLK.volume / 100;
			audioCom.clip = sounds[1];
			audioCom.Play();
		}
	}
}
