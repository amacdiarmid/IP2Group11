using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {
	
	public int choice = 0;
	public AudioClip[] song;
	private int current;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		audio.clip = song[choice];
		current = choice;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if(choice != current)
		{
			audio.clip = song[choice];
			audio.Play ();
			current = choice;
		}
	}

	public int GetChoice()
	{
		return choice;
	}
	
	public void SetChoice(int choice)
	{
		this.choice = choice;
	}
}
