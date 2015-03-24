using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIData : MonoBehaviour {

	private boardTiles board;
	private towerData towers;
	//buy towers
	public GameObject towerUI;
	public Button buyLightning;
	public Button buyLocust;
	public Button buyVolcano;
	public Button buyWall;
	public Text towerText;
	//sell/upgrade towers
	public GameObject upgradeUI;
	public Button upgradeTower;
	public Button sellTower;
	public Text upgradeText;

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
		//remove events
		buyLightning.onClick.RemoveAllListeners();
		buyLocust.onClick.RemoveAllListeners();
		buyVolcano.onClick.RemoveAllListeners();
		buyWall.onClick.RemoveAllListeners();
		upgradeTower.onClick.RemoveAllListeners();
		sellTower.onClick.RemoveAllListeners();
		//add events
		buyLightning.onClick.AddListener(() => a.spawnWall(towers.lightningTower));
		buyLocust.onClick.AddListener(() => a.spawnWall(towers.locustTower));
		buyVolcano.onClick.AddListener(() => a.spawnWall(towers.volcanoTower));
		buyWall.onClick.AddListener(() => a.spawnWall(towers.wallTower));
		//upgrade
		sellTower.onClick.AddListener(() => a.destroyWall());
	}

	public void hide()
	{
		towerUI.SetActive(false);
		upgradeUI.SetActive(false);
	}
}
