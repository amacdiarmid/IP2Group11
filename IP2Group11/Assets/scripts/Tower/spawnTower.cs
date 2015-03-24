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
	private bool UIActive;
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
		UIActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (board.heroSelected == false)
			{		
				Node.Wall = true;
				if (start.startPath() == true)
				{
					if (UIActive == false)
					{
						towerUI.towerUI.SetActive(true);
						towerUI.towerUI.transform.position = this.transform.position;
						towerUI.move(this.gameObject);
						UIActive = true;
					}
					else
					{
						towerUI.towerUI.SetActive(false);
						UIActive = false;
					}
				}
				else
				{
					Node.Wall = false;
				}
			}
			else
			{
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
			UIActive = false;
			playerData.RemoveGold(tempTower.GetComponent<towerBehaviour>().cost);
		}
	}

	public void destroyWall()
	{
		Node.Wall = false;
		wall = false;
		towerUI.towerUI.SetActive(false);
		UIActive = false;
		playerData.AddGold(tower.GetComponent<towerBehaviour>().Refund);
		Destroy(tower);
	}
}
