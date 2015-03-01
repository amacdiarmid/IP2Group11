using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	
	//Texture for the splash screen
	public Texture2D backgroundTexture;
	//Width and height for GUI elements
	public int buttonWidth=100;
	public int buttonHeight=30;
	//The space between the elements
	public int buttonSpacing=70;
	//The start Y position of the elements
	public int buttonYStart=150;
	//variable to store the player's name
	public string nameText="";
	
	void OnGUI()
	{
		//draw splash screen
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		//Enter a text field to store the player name
		nameText=GUI.TextField(new Rect(Screen.width/2-buttonWidth/2,50.0f,buttonWidth,buttonHeight),nameText);
		//Store the start position
		int buttonYPosition=buttonYStart;
		//Store the players name
		GameObject gameData=GameObject.Find("GameData");
		if(gameData!=null)
		{
			GameDataScript gameDataScript=gameData.GetComponent<GameDataScript>();
			gameDataScript.playerName=nameText;
		}
		//add button
		if(GUI.Button(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Start"))
		{
			//load the level
			StartCoroutine(PlayButtonClick());
		}
		//change the position for the next button
		buttonYPosition+=buttonSpacing;
		//add another button
		if(GUI.Button(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Options"))
		{
			//load the level
			StartCoroutine(OptionsButtonClick());	
		}
		//change the position for the next button
		buttonYPosition+=buttonSpacing;
		//add another button
		if(GUI.Button(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Quit"))
		{
			//quit the game
			Application.Quit();
		}
	}
	
	//Play audio clip and load level when finished
	IEnumerator PlayButtonClick()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.LoadLevel("Game");		
	}
	
	//Play audio clip and load level when finished
	IEnumerator OptionsButtonClick()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.LoadLevel("Options");		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
