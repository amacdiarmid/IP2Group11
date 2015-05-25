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
	public int upgradeCost;
	public int Refund;
	public AudioClip[] sounds;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y + 20;
		this.gameObject.GetComponent<CircleCollider2D>().radius = areaOfAttack;
		upgradeCost = cost * 2;
		GetComponent<AudioSource>().clip = sounds[0];
		GetComponent<AudioSource>().Play ();
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
				GetComponent<AudioSource>().clip = sounds[1];
				GetComponent<AudioSource>().Play();
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
		if (this.gameObject.GetComponent<Collider2D>().enabled == false)
		{
			this.gameObject.GetComponent<Collider2D>().enabled = true;
		}
		else
		{
			this.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

	public void UpgradeTower()
	{
		//should use floats for precision
		damage *= 2;
		speed /= 2;
		upgradeCost *= 2;
		Refund *= 2;
		areaOfAttack *= 2;
		this.gameObject.GetComponent<CircleCollider2D>().radius = areaOfAttack;
	}
}
