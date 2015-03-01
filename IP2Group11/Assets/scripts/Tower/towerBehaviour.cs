using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;
	public float RateOfFire;
	public bool canFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canFire == false)
		{
			
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			if (true)
			{
				Debug.Log ("hello");
				GameObject g = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
				g.GetComponent<projectileBehaviour>().target = other.transform;
			}		
		}
	}

	public void HideCollider()
	{
		if (this.gameObject.collider2D.enabled == false)
		{
			this.gameObject.collider2D.enabled = true;
		}
		else
		{
			this.gameObject.collider2D.enabled = false;
		}
	}
}
