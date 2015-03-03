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

	// Use this for initialization
	void Start () 
	{
		Node = this.GetComponent<pathNodes>();
		towerData = GameObject.Find("Game Data").GetComponent<towerData>();
		towerUI = GameObject.Find("Game Data").GetComponent<UIData>();
		start = GameObject.Find("board/start").GetComponent<startNode>();
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
			if (UIActive == false)
			{
				Debug.Log("not blocking path");
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
		
	}

	public void spawnWall(GameObject tempTower)
	{
		if (wall == false && start.startPath() == true)
		{
			Debug.Log("spawn Wall");
			Node.Wall = true;
			wall = true;
			tower = (GameObject)Instantiate(tempTower, this.transform.position, Quaternion.identity);
			tower.transform.parent = transform;
			towerUI.towerUI.SetActive(false);
			UIActive = false;
		}
	}

	public void destroyWall()
	{
		Debug.Log("sell Wall");
		Node.Wall = false;
		wall = false;
		towerUI.towerUI.SetActive(false);
		UIActive = false;
		Destroy(tower);
	}
}
