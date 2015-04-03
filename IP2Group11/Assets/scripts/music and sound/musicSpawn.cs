using UnityEngine;
using System.Collections;

public class musicSpawn : MonoBehaviour {
	
	public GameObject musicPrefab;

	// Use this for initialization
	void Start () {
		if(!(GameObject.Find("backgroundMusic")))
		{
			Instantiate(musicPrefab, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
