using UnityEngine;
using System.Collections;

public class MusicSpawn : MonoBehaviour {
	
	//Variable for the prefab that holds the object for playing music in the menu
	public GameObject mainMenuMusic;

	// Use this for initialization
	void Start () {
		//Checks to see if the game object exists, if not, instantiates it
		if(!(GameObject.FindWithTag ("menumusic")))
		{
			Instantiate(mainMenuMusic, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
