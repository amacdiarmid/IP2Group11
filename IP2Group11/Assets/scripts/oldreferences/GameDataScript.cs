using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {
	
	//A variable to store the player's name
	public string playerName="";
	//A variable to store the player's score
	public int playerScore=0;

	// Use this for initialization
	void Start () {
		//Makes the object persist through scene loads
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
