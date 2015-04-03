using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

	public AudioClip click;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			audio.clip = click;
			audio.Play ();
		}
	}
}
