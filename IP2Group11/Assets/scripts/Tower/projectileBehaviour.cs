using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {

	public float speed = 10;
	public Transform target;
	public PlayerData playerData;
	public int damage;
	private bool hit = false;

	// Use this for initialization
	void Start () {
		playerData = GameObject.Find("Game Data").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			// Fly towards the target        
			Vector3 dir = target.position - transform.position;
			rigidbody2D.velocity = dir.normalized * speed;
		} else {
			// Otherwise destroy self
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Creep")
		{
			Debug.Log("hit");
			if (hit == false)
			{
				hit = true;
				col.gameObject.GetComponent<creepMovement>().HP -= damage;
				Destroy(this.gameObject);
				if (col.gameObject.GetComponent<creepMovement>().HP <= 0)
				{
					playerData.AddGold(5);
					Destroy(col.gameObject);
				}	
			}
				
		}
	}
}
