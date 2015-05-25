using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class spawnTower : MonoBehaviour {

	private pathNodes Node;
	private bool wall;
	private GameObject tower;
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
		Debug.Log("click");
		if (board.heroSelected == false)
		{
			Debug.Log("hero is not active");
			if (wall == true)
			{
				Debug.Log("no current ui on tower");
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
					Debug.Log("no current ui on empty space");
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
					Debug.Log("removing the tower ui");
					playerData.StartCoroutine("ShowError", errorName.location);
					towerUI.visability(false);
					Node.Wall = false;
				}
			}
		}
		else
		{
			Debug.Log("hero is selected");
			board.sendNewPos(transform.position);
		}
	}

	public void spawnWall(GameObject tempTower)
	{
		Debug.Log(tempTower);
		if (wall == false && start.startPath() == true && playerData.playerGold>=tempTower.GetComponent<towerBehaviour>().cost)
		{
			Node.Wall = true;
			wall = true;
			tower = (GameObject)Instantiate(tempTower, this.transform.position, Quaternion.identity);
			tower.transform.parent = transform;
			towerUI.visability(false);
			playerData.RemoveGold(tempTower.GetComponent<towerBehaviour>().cost);
		}
		else
		{
			playerData.StartCoroutine("ShowError", errorName.cost);
		}
	}

	public void destroyWall()
	{
		Node.Wall = false;
		wall = false;
		towerUI.visability(false);
		playerData.AddGold(tower.GetComponent<towerBehaviour>().Refund);
		Destroy(tower);
	}

	public void UpgradeTower()
	{
		if (playerData.playerGold>=tower.GetComponent<towerBehaviour>().upgradeCost)
		{
			towerUI.visability(false);
			playerData.RemoveGold(tower.GetComponent<towerBehaviour>().upgradeCost);
			tower.GetComponent<towerBehaviour>().UpgradeTower();
		}
		else
		{
			playerData.StartCoroutine("ShowError", errorName.cost);
		}
	}

	public int getUpCost()
	{
		if (!tower)
		{
			return 0;
		}
		else
		{
			return tower.gameObject.GetComponent<towerBehaviour>().upgradeCost;
		}
	}

	public int getSellCost()
	{
		if (!tower)
		{
			return 0;
		}
		else
		{
			return tower.gameObject.GetComponent<towerBehaviour>().Refund;
		}
	}
}
