﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	public int playerHealth = 5;
	public int playerGold = 500;
	public Text text;

	// Use this for initialization
	void Start () {
		text = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Life: " + playerHealth + " Gold: " + playerGold;
	}

	public void RemoveHealth(int health)
	{
		playerHealth-=health;
	}

	public void RemoveGold(int gold)
	{
		playerGold-=gold;
	}

	public void AddGold(int gold)
	{
		playerGold+=gold;
	}
}