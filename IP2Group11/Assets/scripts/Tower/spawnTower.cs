using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class spawnTower : MonoBehaviour {

	private pathNodes Node;
	private bool wall;
	private towerBehaviour tower;
	private startNode start;
	private UIData towerUI;
	private boardTiles board;
	private PlayerData playerData;

	// Use this for initialization
	void Start () 
	{
		Node = this.GetComponent<pathNodes>();
		towerUI = GameObject.Find("Game Data").GetComponent<UIData>();
		start = GameObject.Find("board/start").GetComponent<startNode>();
		board = GameObject.Find("board").GetComponent<boardTiles>();
		playerData = GameObject.Find("Game Data").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseUp()
	{
		//Debug.Log("click");
		if (board.heroSelected == false)
		{
			Debug.Log("hero is not active");
			if (wall == true)
			{
				//Debug.Log("no current ui on tower");
				if (towerUI.tempTile == this.gameObject)
				{
					towerUI.visability(false);
				}
				else
				{
					towerUI.visability(true, UIWheel.upgradeWheel, this.gameObject);
				}	
			}
			else
			{
				Node.Wall = true;
				if (start.startPath() == true)
				{
					//Debug.Log("no current ui on empty space");
					Node.Wall = false;
					if (towerUI.tempTile == this.gameObject)
					{
						towerUI.visability(false);
					}
					else
					{
						towerUI.visability(true, UIWheel.BuyWheel,this.gameObject);
					}	
				}
				else
				{
					//Debug.Log("removing the tower ui");
					playerData.StartCoroutine("ShowError", errorName.location);
					towerUI.visability(false);
					Node.Wall = false;
				}
			}
		}
		else
		{
			//Debug.Log("hero is selected");
			board.sendNewPos(transform.position);
		}
	}

	public void buildTower(GameObject tempTower)
	{
		if (wall == false && start.startPath() == true && playerData.playerGold>=tempTower.GetComponent<towerBehaviour>().cost[0])
		{
			Node.Wall = true;
			wall = true;
			Debug.Log(tempTower);
			GameObject intsTower = Instantiate(tempTower, this.transform.position, Quaternion.identity) as GameObject;
			Debug.Log(intsTower);
			tower = intsTower.GetComponent<towerBehaviour>();
			tower.gameObject.transform.parent = this.transform;
			tower.towerLevel = 0;
			towerUI.visability(false);
			playerData.RemoveGold(tempTower.GetComponent<towerBehaviour>().cost[0]);
		}
		else
		{
			playerData.StartCoroutine("ShowError", errorName.cost);
		}
	}

	public void destroyTower()
	{
		Node.Wall = false;
		wall = false;
		towerUI.visability(false);
		playerData.AddGold(tower.Refund[tower.towerLevel]);
		Destroy(tower.gameObject);
	}

	public void UpgradeTower()
	{
		if (tower.towerLevel < tower.maxTowerLevel-1)
		{
			if (playerData.playerGold >= tower.cost[tower.towerLevel + 1])
			{
				towerUI.visability(false);
				tower.towerLevel++;
				playerData.RemoveGold(tower.cost[tower.towerLevel]);
				tower.GetComponent<towerBehaviour>().UpgradeTower();
			}
			else
			{
				playerData.StartCoroutine("ShowError", errorName.cost);
			}
		}
		else
		{
			playerData.StartCoroutine("ShowError", errorName.upgrade);
		}	
	}

	public bool canLevelUp()
	{
		if (tower.towerLevel < tower.maxTowerLevel - 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public string getUpCost()
	{
		//Debug.Log(tower.towerLevel);
		return tower.cost[tower.towerLevel+1].ToString();
	}

	public string getUpDam()
	{
		//Debug.Log(tower.towerLevel);
		return tower.damage[tower.towerLevel + 1].ToString();
	}

	public string getUpRange()
	{
		//Debug.Log(tower.towerLevel);
		return tower.areaOfAttack[tower.towerLevel + 1].ToString();
	}

	public string getUpRateOfFire()
	{
		//Debug.Log(tower.towerLevel);
		return tower.RateOfFire[tower.towerLevel + 1].ToString();
	}

	public int getSellCost()
	{
		return tower.Refund[tower.towerLevel];
	}
}
