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
		towers = PlayerData.data.gameObject.GetComponent<towerData>();
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
			towerText.text = "";
			tempTile = tile;
		}
		else if (wheel == UIWheel.upgradeWheel)
		{
			upgradeUI.SetActive(state);
			upgradeUI.transform.position = tile.transform.position;
			upgradeText.text = "";
			tempTile = tile;
		}
		else
		{
			Debug.Log("UIError");
		}		
	}

	public void buildTower(GameObject tower)
	{
		tempTile.GetComponent<spawnTower>().buildTower(tower);
	}

	public void sellTower()
	{
		tempTile.GetComponent<spawnTower>().destroyTower();
	}

	public void upgradeTower()
	{
		tempTile.GetComponent<spawnTower>().UpgradeTower();
	}

	public void buyHoverText(int ID)
	{
		if (ID == 1)
		{
			towerText.text = "cost: " + towers.lightningTower.GetComponent<towerBehaviour>().cost[0] + "  damage: " + towers.lightningTower.GetComponent<towerBehaviour>().damage[0] + "  range: " + towers.lightningTower.GetComponent<towerBehaviour>().areaOfAttack[0] + "  speed: " + towers.lightningTower.GetComponent<towerBehaviour>().RateOfFire[0];
		}
		else if (ID == 2)
		{
			towerText.text = "cost: " + towers.locustTower.GetComponent<towerBehaviour>().cost[0] + "  damage: " + towers.locustTower.GetComponent<towerBehaviour>().damage[0] + "  range: " + towers.locustTower.GetComponent<towerBehaviour>().areaOfAttack[0] + "  speed: " + towers.locustTower.GetComponent<towerBehaviour>().RateOfFire[0];
		}
		else if (ID == 3)
		{
			towerText.text = "cost: " + towers.volcanoTower.GetComponent<towerBehaviour>().cost[0] + "  damage: " + towers.volcanoTower.GetComponent<towerBehaviour>().damage[0] + "  range: " + towers.volcanoTower.GetComponent<towerBehaviour>().areaOfAttack[0] + "  speed: " + towers.volcanoTower.GetComponent<towerBehaviour>().RateOfFire[0];
		}
		else if (ID == 4)
		{
			towerText.text = "cost: " + towers.wallTower.GetComponent<towerBehaviour>().cost[0];
		}
	}

	public void upgradeHoverText(int ID)
	{
		if (ID == 1)
		{
			if (tempTile.GetComponent<spawnTower>().canLevelUp() == true)
			{
				upgradeText.text = "cost: " + tempTile.GetComponent<spawnTower>().getUpCost() + "  damage: " + tempTile.GetComponent<spawnTower>().getUpDam() + "  range: " + tempTile.GetComponent<spawnTower>().getUpRange() + "  speed: " + tempTile.GetComponent<spawnTower>().getUpRateOfFire();
			}
			else
			{
				upgradeText.text = "Max Level";
			}
		}
		else if (ID == 2)
		{
			upgradeText.text = "refund: " + tempTile.GetComponent<spawnTower>().getSellCost();
		}
	}
}
