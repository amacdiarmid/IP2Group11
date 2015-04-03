using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	//the wave data variable
	private WaveData wave;
	//players current gold and health
	public int playerHealth;
	public int playerGold;
	//text objects to be modified to show gold health and wave
	public Text goldText;
	public Text healthText;
	public Text waveText;
	//buttons to show next level, retry and quit(i.e. go to main menu)
	public Button level;
	public Button retry;
	public Button quit;

	// Use this for initialization
	void Start () {
		//sets the game to play(out of pause mode)
		Time.timeScale = 1;
		//gets the wave data object
		wave = GameObject.Find("Game Data").GetComponent<WaveData>();
		//hides the buttons
		retry.gameObject.SetActive(false);
		quit.gameObject.SetActive(false);
		level.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//updats the current gold health and wave infomation
		goldText.text = "" + playerGold;
		healthText.text = "" + playerHealth;
		waveText.text = "" + wave.curWave + "/" +wave.BasicCreepCount.Count;
	}
	/// <summary>
	/// this is called when a player reaches the nexus
	/// takes in how much health has to be lost
	/// </summary>
	/// <param name="health"></param>
	public void RemoveHealth(int health)
	{
		//removes from the total health
		playerHealth-=health;
		//checks to see if the player has reached 0 health
		if (playerHealth <= 0)
		{
			//show the retry and quit buttons
			retry.gameObject.SetActive(true);
			quit.gameObject.SetActive(true);
			//set the game to pause 
			Time.timeScale = 0;
		}
	}
	/// <summary>
	/// removes the gold amout from the total
	/// called from tower buy/upgrade events
	/// </summary>
	/// <param name="gold"></param>
	public void RemoveGold(int gold)
	{
		playerGold -= gold;
	}
	/// <summary>
	/// adds the gold ammout to the total
	/// called from creep being killed and selling towers
	/// </summary>
	/// <param name="gold"></param>
	public void AddGold(int gold)
	{
		playerGold += gold;
	}
	/// <summary>
	/// called on reaching final wave and defeating all the creeps
	/// </summary>
	public void victory()
	{
		//show buttons 
		retry.gameObject.SetActive(true);
		quit.gameObject.SetActive(true);
		level.gameObject.SetActive(true);
		//set game to pause
		Time.timeScale = 0;
	}
	//loads the level from the string in the OnClick buttion even in the inspector
	public void nextLevel(string name)
	{
		Application.LoadLevel(name);
	}
}