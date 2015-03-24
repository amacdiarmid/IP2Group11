using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;
	public float RateOfFire;
	private bool canFire = true;
	public float areaOfAttack;
	public int damage;
	public int speed;
	public int cost;
	public int Refund;

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
		if(other.gameObject.tag=="Creep")
		{
			if (canFire == true)
			{			
				GameObject shot = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
				shot.GetComponent<projectileBehaviour>().target = other.transform;
				shot.GetComponent<projectileBehaviour>().damage = damage;
				shot.GetComponent<projectileBehaviour>().speed = speed;
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
