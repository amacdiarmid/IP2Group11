using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum errorName
{
	location,
	cost,
	upgrade
};

public class PlayerData : MonoBehaviour {

	//the wave data variable
	private waveControl wave;
	//players current gold and health
	public int playerHealth;
	public int playerGold;
	//text objects to be modified to show gold health and wave
	public Text goldText;
	public Text healthText;
	public Text waveText;
	public Text errorText;
	//buttons to show next level, retry and quit(i.e. go to main menu)
	public Button level;
	public Button retry;
	public Button quit;
	private bool pause;
	public int levelNo;

	// Use this for initialization
	void Start () {
		//sets the game to play(out of pause mode)
		Time.timeScale = 1;
		//gets the wave data object
		wave = GameObject.Find("Game Data").GetComponent<waveControl>();
		//hides the buttons
		retry.gameObject.SetActive(false);
		quit.gameObject.SetActive(false);
		level.gameObject.SetActive(false);
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		//updats the current gold health and wave infomation
		goldText.text = "" + playerGold;
		healthText.text = "" + playerHealth;
		waveText.text = "" + wave.curWave + "/" +wave.totalWaves;

		if (Input.GetButtonUp("pause"))
		{
			pauseMenu();
		}
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
		if (saveData.saveControl.basicLevelActive <= levelNo)
		{
			saveData.saveControl.basicLevelActive = levelNo + 1;
		}
		if (playerHealth == 20)
		{
			errorText.text = "3/3 points";
			if (saveData.saveControl.basicLevelScore[levelNo - 1] < 3)
			{
				saveData.saveControl.basicLevelScore[levelNo - 1] = 3;
			}
		}
		else if (playerHealth >= 10)
		{
			errorText.text = "2/3 points";
			if (saveData.saveControl.basicLevelScore[levelNo - 1] < 2)
			{
				saveData.saveControl.basicLevelScore[levelNo - 1] = 2;
			}
		}
		else
		{
			errorText.text = "1/3 points";
			if (saveData.saveControl.basicLevelScore[levelNo - 1] < 1)
			{
				saveData.saveControl.basicLevelScore[levelNo - 1] = 1;
			}
		}
	}
	//loads the level from the string in the OnClick buttion even in the inspector
	public void nextLevel(string name)
	{
		Application.LoadLevel(name);
	}

	public IEnumerator ShowError(errorName error)
	{
		string text;
		if (error == errorName.cost)
		{
			text = "Not enough gold";
		}
		else if (error == errorName.location)
		{
			text = "Can't place tower here";
		}
		else if (error == errorName.upgrade)
		{
			text = "Maximum tower level";
		}
		else
		{
			text = "";
		}
		errorText.text = text;
		yield return new WaitForSeconds(1.0f);
		errorText.text = "";
	}

	public void pauseMenu()
	{
		if (pause == false)
		{
			pause = true;
			Time.timeScale = 0;
			retry.gameObject.SetActive(true);
			quit.gameObject.SetActive(true);
		}
		else
		{
			pause = false;
			Time.timeScale = 1;
			retry.gameObject.SetActive(false);
			quit.gameObject.SetActive(false);
		}		
	}
}