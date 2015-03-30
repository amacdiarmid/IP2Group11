using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	private WaveData wave;
	public int playerHealth;
	public int playerGold;
	public Text goldText;
	public Text healthText;
	public Text waveText;
	public Button level;
	public Button retry;
	public Button quit;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		wave = GameObject.Find("Game Data").GetComponent<WaveData>();
		retry.gameObject.SetActive(false);
		quit.gameObject.SetActive(false);
		level.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		goldText.text = "" + playerGold;
		healthText.text = "" + playerHealth;
		waveText.text = "" + wave.curWave + "/" +wave.BasicCreepCount.Count;
	}

	public void RemoveHealth(int health)
	{
		playerHealth-=health;
		if (playerHealth <= 0)
		{
			retry.gameObject.SetActive(true);
			quit.gameObject.SetActive(true);
			goldText.text = "Life: " + playerHealth + " Gold: " + playerGold +"game over";
			Time.timeScale = 0;
		}
	}
	public void RemoveGold(int gold)
	{
		playerGold -= gold;
	}

	public void AddGold(int gold)
	{
		playerGold += gold;
	}

	public void victory()
	{
		retry.gameObject.SetActive(true);
		quit.gameObject.SetActive(true);
		level.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void nextLevel(string name)
	{
		Application.LoadLevel(name);
	}
}