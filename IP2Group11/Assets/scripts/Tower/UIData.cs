using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIData : MonoBehaviour {

	private boardTiles board;
	private towerData towers;
	public GameObject towerUI;
	public Button buyLightning;
	public Button sellTower;

	// Use this for initialization
	void Start () 
	{
		board = GameObject.Find("board").GetComponent<boardTiles>();
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(GameObject tile)
	{
		spawnTower a = tile.GetComponent<spawnTower>();
		buyLightning.onClick.RemoveAllListeners();
		sellTower.onClick.RemoveAllListeners();
		buyLightning.onClick.AddListener(() => a.spawnWall(towers.lightningTower));
		sellTower.onClick.AddListener(() => a.destroyWall());
	}
}
