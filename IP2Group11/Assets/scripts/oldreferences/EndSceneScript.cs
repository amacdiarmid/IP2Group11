using UnityEngine;
using System.Collections;

public class EndSceneScript : MonoBehaviour {
	
	//Texture for the splash screen
	public Texture2D backgroundTexture;
	//Width and height for GUI elements
	public int buttonWidth=100;
	public int buttonHeight=30;
	//The space between the elements
	public int buttonSpacing=70;
	//The start Y position of the elements
	public int buttonYStart=75;
	
	void OnGUI()
	{
		//Checks for the persistent data object
		GameObject gameData=GameObject.Find ("GameData");
		if(gameData!=null)
		{
			GameDataScript gameDataScript=gameData.GetComponent<GameDataScript>();
			//Draw splash screen
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
			//Store the start position
			int buttonYPosition=buttonYStart;
			//Add label
			GUI.Label(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Game Over!");
			//Change the position for the next button
			buttonYPosition+=buttonSpacing;
			//Add another label
			GUI.Label(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Your score was: "+gameDataScript.playerScore.ToString());
			//Change the position for the next button
			buttonYPosition+=buttonSpacing;
			//Add button
			if(GUI.Button(new Rect(Screen.width/2-buttonWidth/2,buttonYPosition,buttonWidth,buttonHeight), "Main Menu"))
			{
				//load the level
				StartCoroutine(MenuButtonClick());
			}
		}
	}
	
	//Play audio clip and load level when finished
	IEnumerator MenuButtonClick()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.LoadLevel("MainMenu");		
	}

	// Use this for initialization
	void Start () {
		//Enable the cursor again
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
