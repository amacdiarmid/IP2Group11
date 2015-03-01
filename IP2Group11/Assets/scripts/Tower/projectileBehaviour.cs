using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {

	public float speed = 10;
	public Transform target;
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
}
