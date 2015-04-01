using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIData : MonoBehaviour {

	private boardTiles board;
	private towerData towers;
	//buy towers
	public GameObject towerUI;
	private Vector3 towerPos;
	private bool towerMoved;
	public Button buyLightning;
	public Button buyLocust;
	public Button buyVolcano;
	public Button buyWall;
	public Text towerText;
	//sell/upgrade towers
	public GameObject upgradeUI;
	private Vector3 upgradePos;
	private bool upgradeMoved;
	public Button upgradeTower;
	public Button sellTower;
	public Text upgradeText;

	// Use this for initialization
	void Start () 
	{
		board = GameObject.Find("board").GetComponent<boardTiles>();
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
		towerPos = towerUI.transform.position;
		upgradePos = upgradeUI.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
		sellTower.onClick.AddListener(() => a.destroyWall());
		upgradeTower.onClick.AddListener (() => a.UpgradeTower());
		//add text
		towerText.text = towers.lightningTower.GetComponent<towerBehaviour>().cost + "  " + towers.locustTower.GetComponent<towerBehaviour>().cost + "  " + towers.volcanoTower.GetComponent<towerBehaviour>().cost + "  " + towers.wallTower.GetComponent<towerBehaviour>().cost;
		upgradeText.text = a.GetComponent<spawnTower>().getUpCost() + "  " + a.GetComponent<spawnTower>().getSellCost();
	}

	public void hide()
	{
		if (towerMoved == false)
		{
			towerUI.transform.position = towerPos;
		}
		if (upgradeMoved == false)
		{
			upgradeUI.transform.position = upgradePos;
		}	
	}
}
