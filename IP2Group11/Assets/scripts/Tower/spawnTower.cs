using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class spawnTower : MonoBehaviour {

	private bool mouseOver;
	private bool mouseDown;
	private towerData towerData;
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
		towerData = GameObject.Find("Game Data").GetComponent<towerData>();
		towerUI = GameObject.Find("Game Data").GetComponent<UIData>();
		start = GameObject.Find("board/start").GetComponent<startNode>();
		board = GameObject.Find("board").GetComponent<boardTiles>();
		playerData = GameObject.Find("Game Data").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		Debug.Log("click");
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			Debug.Log("no ui in the way");
			if (board.heroSelected == false)
			{
				Debug.Log("hero is not active");
				if (wall == true)
				{
					Debug.Log("no current ui on tower");
					towerUI.upgradeUI.SetActive(true);
					towerUI.towerUI.SetActive(false);
					towerUI.upgradeUI.transform.position = this.transform.position;
					towerUI.move(this.gameObject);
				}
				else
				{
					Node.Wall = true;
					if (start.startPath() == true)
					{
						Debug.Log("no current ui on empty space");
						Node.Wall = false;
						towerUI.towerUI.SetActive(true);
						towerUI.upgradeUI.SetActive(false);
						towerUI.towerUI.transform.position = this.transform.position;
						towerUI.move(this.gameObject);
					}
					else
					{
						Debug.Log("removing the tower ui");
						towerUI.towerUI.SetActive(false);
						towerUI.upgradeUI.SetActive(false);
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
	}

	public void spawnWall(GameObject tempTower)
	{
		if (wall == false && start.startPath() == true && playerData.playerGold>=tempTower.GetComponent<towerBehaviour>().cost)
		{
			Node.Wall = true;
			wall = true;
			tower = (GameObject)Instantiate(tempTower, this.transform.position, Quaternion.identity);
			tower.transform.parent = transform;
			towerUI.towerUI.SetActive(false);
			playerData.RemoveGold(tempTower.GetComponent<towerBehaviour>().cost);
		}
	}

	public void destroyWall()
	{
		Node.Wall = false;
		wall = false;
		towerUI.upgradeUI.SetActive(false);
		playerData.AddGold(tower.GetComponent<towerBehaviour>().Refund);
		Destroy(tower);
	}
}
