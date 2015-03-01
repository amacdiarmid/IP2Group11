using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;
	public Collider2D target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator TowerFire()
	{
		Debug.Log ("Tower fired");
		GameObject g = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
		g.GetComponent<projectileBehaviour>().target = target.transform;
		yield return new WaitForSeconds(2);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			target = other;
			StartCoroutine(TowerFire ());
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			target = other;
			StartCoroutine(TowerFire ());
		}
	}
}
