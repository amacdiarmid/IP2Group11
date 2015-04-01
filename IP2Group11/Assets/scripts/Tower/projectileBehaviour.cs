using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {

	[HideInInspector] public float speed = 10;
	[HideInInspector] public Transform target;
	[HideInInspector] public int damage;
	private bool hit = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y;
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
				animator.SetTrigger("explode");
			}		
		}
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}
