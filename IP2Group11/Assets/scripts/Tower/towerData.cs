using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class towerData : MonoBehaviour {

	public GameObject lightningTower;
	[HideInInspector] public List<towerBehaviour> towers;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hideCollider()
	{
		towers.Clear();
		foreach (GameObject tower in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (tower.tag == "Tower")
			{
				towers.Add(tower.GetComponent<towerBehaviour>());
				tower.GetComponent<towerBehaviour>().HideCollider();
			}
		}
	}
}
