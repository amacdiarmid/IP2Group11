using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {
	
	public int choice = 0;
	public AudioClip[] song;
	private int current;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		GetComponent<AudioSource>().clip = song[choice];
		current = choice;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if(choice != current)
		{
			GetComponent<AudioSource>().clip = song[choice];
			GetComponent<AudioSource>().Play ();
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
