using UnityEngine;
using System.Collections;
using System.Linq;

public class endNode : pathNodes {

	public boardTiles board;

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
		board = GameObject.Find("board").GetComponent<boardTiles>();
		Up = true;
		Down = true;
		Left = true;
		Right = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool recieveRay()
	{
		if (done == false)
		{
			done = true;
			path.Add(this.transform.position);
			path = path.Distinct().ToList();
			return true;
		}
		else
		{
			return false;	
		} 
	}
}
