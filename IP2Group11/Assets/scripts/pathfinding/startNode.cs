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
				hitUpS.collider.GetComponent<pathNodes>().Down = true;
				hitUpS.collider.GetComponent<pathNodes>().path = path;
				hitUpS.collider.GetComponent<pathNodes>().recieveRay();
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
				hitDownS.collider.GetComponent<pathNodes>().Up = true;
				hitDownS.collider.GetComponent<pathNodes>().path = path;
				hitDownS.collider.GetComponent<pathNodes>().recieveRay();
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
				hitLeftS.collider.GetComponent<pathNodes>().Right = true;
				hitLeftS.collider.GetComponent<pathNodes>().path = path;
				hitLeftS.collider.GetComponent<pathNodes>().recieveRay();
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
				hitRightS.collider.GetComponent<pathNodes>().Left = true;
				hitRightS.collider.GetComponent<pathNodes>().path = path;
				hitRightS.collider.GetComponent<pathNodes>().recieveRay();
			}
		}
	}
}
