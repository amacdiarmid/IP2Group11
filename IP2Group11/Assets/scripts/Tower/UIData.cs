using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum UIWheel
{
	BuyWheel,
	upgradeWheel
};

public class UIData : MonoBehaviour {

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
	public Button upgradeTowerBut;
	public Button sellTowerBut;
	public Text upgradeText;
	[HideInInspector] public GameObject tempTile;

	// Use this for initialization
	void Start () 
	{
		towers = GameObject.Find("Game Data").GetComponent<towerData>();
	}

	public void visability(bool state)
	{
		upgradeUI.SetActive(false);
		towerUI.SetActive(false);
		tempTile = null;
	}

	public void visability(bool state, UIWheel wheel, GameObject tile)
	{
		if (wheel == UIWheel.BuyWheel)
		{
			towerUI.SetActive(state);
			towerUI.transform.position = tile.transform.position;
			towerText.text = towers.lightningTower.GetComponent<towerBehaviour>().cost + "  " + towers.locustTower.GetComponent<towerBehaviour>().cost + "  " + towers.volcanoTower.GetComponent<towerBehaviour>().cost + "  " + towers.wallTower.GetComponent<towerBehaviour>().cost;
			tempTile = tile;
		}
		else if (wheel == UIWheel.upgradeWheel)
		{
			upgradeUI.SetActive(state);
			upgradeUI.transform.position = tile.transform.position;
			upgradeText.text = tile.GetComponent<spawnTower>().getUpCost() + "  " + tile.GetComponent<spawnTower>().getSellCost();
			tempTile = tile;
		}
		else
		{
			Debug.Log("UIError");
		}		
	}

	public void buildTower(GameObject tower)
	{
		tempTile.GetComponent<spawnTower>().spawnWall(tower);
	}

	public void sellTower()
	{
		tempTile.GetComponent<spawnTower>().destroyWall();
	}

	public void upgradeTower()
	{
		tempTile.GetComponent<spawnTower>().UpgradeTower();
	}
}
