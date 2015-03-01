using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;
	public float RateOfFire;
	private bool canFire = true;
	public float areaOfAttack;
	public int damage;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<CircleCollider2D>().radius = areaOfAttack;	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("something inside collider");
		if(other.gameObject.tag=="Creep")
		{
			Debug.Log ("creep inside collider");
			if (canFire == true)
			{			
				GameObject shot = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
				shot.GetComponent<projectileBehaviour>().target = other.transform;
				shot.GetComponent<projectileBehaviour>().damage = damage;
				canFire = false;
				StartCoroutine("Wait");
			}		
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(RateOfFire);
		canFire = true;
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
