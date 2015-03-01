using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {
	
	//Texture for the splash screen
	public Texture2D backgroundTexture;
	//Width and height for GUI elements
	public int buttonWidth=100;
	public int buttonHeight=30;
	//The space between the elements
	public int buttonSpacing=70;
	//The start Y position of the elements
	public int buttonYStart=150;
	
	void OnGUI()
	{
		//draw splash screen
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		//Store the start position
		int buttonYPosition=buttonYStart;
		//add button
		if(GUI.Button(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Back"))
		{
			//load the level
			StartCoroutine(BackButtonClick());
		}
	}
	
	//Play audio clip and load level when finished
	IEnumerator BackButtonClick()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.LoadLevel("MainMenu");		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
