using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			Debug.Log ("hello");
			GameObject g = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			g.GetComponent<projectileBehaviour>().target = other.transform;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			Debug.Log ("hello");
			GameObject g = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
			g.GetComponent<projectileBehaviour>().target = other.transform;
		}
	}
}
