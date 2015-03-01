using UnityEngine;
using System.Collections;

public class SpawnTriggerScript : MonoBehaviour {
	
	//Variable to hold the spawn point with the spawn script
	public SpawnScript spawnScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//When the player collides calls the Spawn method and plays an audio clip
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			spawnScript.Spawn();
			audio.Play();			
		}
	}
}
