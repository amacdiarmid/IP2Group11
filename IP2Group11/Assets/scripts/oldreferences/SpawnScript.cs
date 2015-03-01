using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	//variable to hold the prefab to be spawned
	public GameObject spawnPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//spawn two prefabs
	public void Spawn()
	{
		GameObject barrel1=(GameObject)Instantiate(spawnPrefab,transform.position,Quaternion.identity);
		GameObject barrel2=(GameObject)Instantiate(spawnPrefab,transform.position,Quaternion.identity);
	}
}
