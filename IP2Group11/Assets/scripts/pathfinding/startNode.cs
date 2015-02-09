using UnityEngine;
using System.Collections;

public class startNode : pathNodes {

	// Use this for initialization
	void Start () 
	{
		detectPath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startPath()
	{
		path.Add(transform.position);
		Vector2 origin;
		Vector2 size;
		//send ray up
		if (Up == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
			RaycastHit2D hitUpS = Physics2D.Raycast(origin + size, Vector2.up);
			if (hitUpS)
			{
				Up = false;
				var tile = hitUpS.collider.GetComponentInChildren<pathNodes>();
				tile.Down = true;
				sendPath(tile);	
			}
		}
		//send ray down
		if (Down == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2(0, (collider2D.bounds.size.y / 2) + 0.1f);
			RaycastHit2D hitDownS = Physics2D.Raycast(origin - size, -Vector2.up);
			if (hitDownS)
			{
				Down = false;
				var tile = hitDownS.collider.GetComponentInChildren<pathNodes>();
				tile.Up = true;
				sendPath(tile);	
			}
		}
		//send ray left
		if (Left == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
			RaycastHit2D hitLeftS = Physics2D.Raycast(origin - size, -Vector2.right);
			if (hitLeftS)
			{
				Left = false;
				var tile = hitLeftS.collider.GetComponentInChildren<pathNodes>();
				tile.Right = true;
				sendPath(tile);				
			}
		}
		//send ray right
		if (Right == true)
		{
			origin = new Vector2(this.transform.position.x, this.transform.position.y);
			size = new Vector2((collider2D.bounds.size.x / 2) + 0.1f, 0);
			RaycastHit2D hitRightS = Physics2D.Raycast(origin + size, Vector2.right);
			if (hitRightS)
			{
				Right = false;
				var tile = hitRightS.collider.GetComponentInChildren<pathNodes>();
				tile.Left = true;
				sendPath(tile);	
			}
		}
	}
}
