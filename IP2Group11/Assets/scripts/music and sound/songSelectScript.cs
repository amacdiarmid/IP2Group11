using UnityEngine;
using System.Collections;

public class songSelectScript : MonoBehaviour {

	private backgroundMusic music;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeSong (int number) 
	{
		music = GameObject.FindWithTag ("Music").GetComponent<backgroundMusic>();
		music.SetChoice(number);
	}
}
