using UnityEngine;
using System.Collections;

public class menuData : MonoBehaviour {

	//loads the level from the string in the OnClick buttion even in the inspector
	public void nextLevel(string name)
	{
		Application.LoadLevel(name);
	}
	//quits the game. called from the onClick event in the inspector
	public void quit()
	{
		Application.Quit();
	}
}
