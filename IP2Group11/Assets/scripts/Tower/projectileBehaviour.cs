using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {

	[HideInInspector] public float speed = 10;
	[HideInInspector] public Transform target;
	[HideInInspector] public int damage;
	private bool hit = false;
	private Animator animator;
	private Vector3 startPos;
	private float startTime;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		startPos = this.transform.position;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y + 30;
		if (target) 
		{
			// Fly towards the target        
			float distCovered = (Time.time - startTime) * speed;
			float journeyLength = Vector3.Distance(startPos, target.position);
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPos, target.position, fracJourney);
		} 
		else 
		{
			// Otherwise destroy self
			Destroy(this.gameObject);
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
				col.gameObject.GetComponent<creepMovement>().materialChange();
				animator.SetTrigger("explode");
			}		
		}
	}
	void Destroy()
	{
		Destroy(this.gameObject);
	}
}
