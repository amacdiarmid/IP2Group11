using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {

	[HideInInspector] public float speed = 10;
	[HideInInspector] public Transform target;
	[HideInInspector] public int damage;
	private bool hit = false;

	// Use this for initialization
	void Start () {
	
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
			if (hit == false)
			{
				hit = true;
				col.gameObject.GetComponent<creepMovement>().removeHealth(damage);
				Destroy(this.gameObject);	
			}		
		}
	}
}
